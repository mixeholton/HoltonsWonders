using Komit.CompanionApp.Component.Model;
using Microsoft.AspNetCore.Components;
using MixeWonders.Client.ViewModels;
using MixeWonders.View.Components;
using MixeWonders.Values.Enums;
using MixeWonders.Values.Services;
using MixeWonders.Values.Values;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace MixeWonders.Client.Helpers
{
    public class WireFrameFunctionHelper<T, TForm, TService>
    {
        public FormMode Form { get; set; } = FormMode.None;
        public T? SelectedItem { get; set; } = default;
        public List<T>? Database { get; set; } = default;
        private IDialogService Dialog { get; set; }
        private ISnackbar SnackbarService { get; set; }
        private TForm? GenericForm { get; set; } = default;
        private TService GenericService { get; set; }
        private Func<Task> UpdateSite {  get; set; }
        public CustomTreeItemData? selectedTreeValue { get; set; }
        public IReadOnlyCollection<TreeItemData<CustomTreeItemData>> treeItems { get; set; } = new List<TreeItemData<CustomTreeItemData>>();
        public CreditDebitValue? SelectedBill { get; set; } = null;
        public UserInfoValue? UserForBill => Database?.Cast<UserInfoValue?>()?.SingleOrDefault(x => x.Name == (selectedTreeValue?.ParentName ?? "")) ?? null;
        public List<UserInfoValue>? UserListForBill => SelectedBill?.Balance == BalanceCurrencyType.Credit ?
                                Database?.Cast<UserInfoValue>().Where(x => x.Account.Credits.Contains(SelectedBill)).ToList() :
                                Database?.Cast<UserInfoValue>().Where(x => SelectedBill != null && x.Account.Debits.Contains(SelectedBill)).ToList() ?? null;

        public WireFrameFunctionHelper(List<T>? values, TForm? form, TService service, IDialogService dialog, ISnackbar snackbar, Func<Task> updateSite)
        {
            SelectedItem = default;
            Database = values;
            Dialog = dialog;
            SnackbarService = snackbar;
            GenericForm = form;
            GenericService = service;            
            treeItems = GetTreeItems(values);
            UpdateSite = updateSite;

        }

        public List<TreeItemData<CustomTreeItemData>> GetTreeItems(List<T> TypeOfTreeItems) => TypeOfTreeItems switch
        {
            List<UserInfoValue> userValues => TreeItemsHelper.GenerateUserCreditTreeData(userValues),
            List<UserHeaderValue> userValues => TreeItemsHelper.GenerateSimpleUserTreeData(userValues),
            _ => throw new ArgumentException("Unsupported type of tree items."),
        };

        public async Task ClickHandler(FormMode formMode)
        {
            Form = formMode;

            if (Form == FormMode.Delete && SelectedItem != null)
            {
                await DeleteSafetyModuleBox();
            }
        }

        public async Task Create(TForm userFormData)
        {
            Form = FormMode.None;
            if (userFormData is UserValidationForm userValue)
            {
                var user = new UserHeaderValue(userValue.Name);
                await (GenericService as UserService).Commands.CreateUserAsync(user);
                ShowInfo(Severity.Success, $"Bruger {userValue.Name} blev oprettet!");
                await UpdateTreeItems();
            }
            else
            {
                ShowInfo(Severity.Error, $"Brugeren blev IKKE oprettet!");
            }
        }

        public async Task Update(TForm userFormData)
        {
            Form = FormMode.None;
            if (userFormData is UserValidationForm userForm)
            {

                var user = new UserHeaderValue(userForm.Name);
                await (GenericService as UserService).Commands.UpdateUserAsync(user);
                ShowInfo(Severity.Success, $"Bruger {userForm.Name} blev opdateret!");
                await UpdateTreeItems();
            }
            else
            {
                ShowInfo(Severity.Error, $"Brugeren blev IKKE opdateret!");
            }
        }
        public void ResetForm()
        {
            Form = FormMode.None;
        }

        private async Task DeleteSafetyModuleBox()
        {
            var dialogSettings = DialogHelper.DefaultDialogSettings("");
            if (SelectedItem is UserInfoValue user)
            {
                dialogSettings = DialogHelper.DefaultDialogSettings($"Vil du slette {user.Name}?");
            }
            var dialog = Dialog.Show<InfoDialog>("Sletning af bruger", dialogSettings.Parameters, dialogSettings.Options);
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                await DeleteUser();
                SelectedItem = default;
            }
        }

        private async Task DeleteUser()
        {
            Form = FormMode.None;
            if (SelectedItem is UserInfoValue user)
            {
                //(GenericService as UserService).Commands(userFormData.User.UserName);
                ShowInfo(Severity.Success, $"Bruger {user.Name} blev slettet!");
            }
            else
            {
                ShowInfo(Severity.Error, $"Brugeren blev IKKE slettet!");

            }
            await UpdateTreeItems();
        }


        private void ShowInfo(Severity severity, string text)
        {
            SnackbarService.Add(text, severity, options =>
            {
                options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Prevent;
            });
        }
        public async Task SelectClick(CustomTreeItemData treeItem)
        {
            if (SelectedItem is UserInfoValue user)
            {

                if (treeItem.TreeNodeType == TreeNodeType.User)
                {
                    user = Database.Cast<UserInfoValue>().SingleOrDefault(x => x.Name == treeItem.Name);
                    SelectedBill = null;
                }
                if (treeItem.TreeNodeType == TreeNodeType.Bill)
                {
                    var selectedUser = Database.Cast<UserInfoValue>().SingleOrDefault(x => x.Name == treeItem.ParentName);
                    user = null;
                    SelectedBill = selectedUser?.Account.Credits.FirstOrDefault(x => x.Id == treeItem.Id) ?? selectedUser.Account.Debits.FirstOrDefault(x => x.Id == treeItem.Id) ?? null;
                }
                Form = treeItem.TreeNodeType == TreeNodeType.User ? FormMode.Update : FormMode.None;
            }
        }

        private List<UserInfoValue> GetUsersCredits(UserValidationForm userFormData, List<UserInfoValue> userValues)
        {
            var creditDebit = new CreditDebitValue(
                userFormData.CreditDebitId,
                userFormData.Description,
                userFormData.Amount,
                userFormData.IsCredit ? BalanceCurrencyType.Credit : BalanceCurrencyType.Debit);

            var existingUser = userValues.FirstOrDefault(x => x.Name == userFormData.Name);
            var user = new UserInfoValue(
                userFormData.userValue.Id,
                userFormData.userValue.AffiliationId,
                userFormData.Name,
                GetNewListOfCreditDebit(
                    userFormData.IsCredit,
                    existingUser?.Account.Credits ?? new List<CreditDebitValue>(),
                    existingUser?.Account.Debits ?? new List<CreditDebitValue>(),
                    creditDebit)
            );

            var result = userFormData.CreditDebitUsers
                .Select(x => new UserInfoValue(
                    x.Id,
                    x.AffiliationId,
                    x.Name,
                    GetNewListOfCreditDebit(
                        !userFormData.IsCredit,
                        x.Account.Credits,
                        x.Account.Debits,
                        creditDebit)
                    )
                ).ToList();

            result.Add(user);

            return result;
        }

        private AccountCreditDebit GetNewListOfCreditDebit(
            bool isCredit,
            List<CreditDebitValue> credits,
            List<CreditDebitValue> debits,
            CreditDebitValue newCreditDebit)
        {
            if (isCredit)
            {
                credits.Add(newCreditDebit);
            }
            else
            {
                debits.Add(newCreditDebit);
            }

            return new AccountCreditDebit(credits, debits);
        }

        private async Task UpdateTreeItems()
        {
            await UpdateSite.Invoke();
        }
    }
}
