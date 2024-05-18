
namespace MixeWonders.Client.Helpers
{
    using MixeWonders.Client.ViewModels;
    using MixeWonders.Model.Enums;
    using MixeWonders.Model.Values;
    using MudBlazor;

    public static class TreeItemsHelper
    {
        public static string ROOT_SYSTEM_NAME = "Systemer";
        public static string ROOT_USER_NAME = "Brugere";

        public static HashSet<TreeItemData> GenerateUserTreeData(List<UserValue> Users)
        {
            if (Users != null)
            {
                return new HashSet<TreeItemData>
                {
                    new TreeItemData
                    {
                        Id = 0,
                        Name = ROOT_USER_NAME,
                        DisplayName = ROOT_USER_NAME,
                        Typography = Typo.h6,
                        IsExpanded = true,
                        TreeNodeType = TreeNodeType.Top,
                        TreeItemChildren = Users
                            .Where(x => x != null)
                            .Select(u => new TreeItemData
                            {
                                Id = u.Id ?? 0,
                                ParentName = ROOT_USER_NAME,
                                Name = u.Name,
                                DisplayName = u.Name,
                                TreeNodeType = TreeNodeType.User,
                                Icon = Icons.Material.Filled.Person,
                                TreeItemChildren = [..u.Account.Credits.Select(b => new TreeItemData()
                                {
                                    Id = b.Id ?? 0,
                                    ParentName = u.Name,
                                    DisplayName = $"{b.Description} : {b.Amount}",
                                    Name = b.Description + " : " + b.Amount,
                                    TreeNodeType = TreeNodeType.Bill,
                                    Typography = Typo.subtitle2,
                                    Icon = Icons.Material.Filled.Money
                                }).ToHashSet(),
                                ..u.Account.Debits.Select(b => new TreeItemData()
                                {
                                    Id = b.Id ?? 0,
                                    ParentName = u.Name,
                                    DisplayName = $"{b.Description} : {b.Amount}",
                                    Name = b.Description + " : " + b.Amount,
                                    TreeNodeType = TreeNodeType.Bill,
                                    Typography = Typo.subtitle2,
                                    Icon = Icons.Material.Filled.Money
                                }).ToHashSet()]
                            }).ToHashSet()
                    }
                };
            }
            else
            {
                return new HashSet<TreeItemData>();
            }
        }


    }
}
