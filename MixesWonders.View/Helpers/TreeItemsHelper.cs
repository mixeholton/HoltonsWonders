
namespace MixeWonders.Client.Helpers
{
    using MixeWonders.Client.ViewModels;
    using MixeWonders.Values.Enums;
    using MixeWonders.Values.Values;
    using MudBlazor;
    using System.Linq;

    public static class TreeItemsHelper
    {
        public static string ROOT_SYSTEM_NAME = "Systemer";
        public static string ROOT_USER_NAME = "Brugere";

        public static List<TreeItemData<CustomTreeItemData>> GenerateUserCreditTreeData(List<UserValue> Users)
        {
            if (Users != null)
            {
                return new List<TreeItemData<CustomTreeItemData>>()
                {
                    new TreeItemData(new CustomTreeItemData(0, TreeNodeType.Top, ROOT_USER_NAME, null, null, null, true, Typo.h6))
                    {
                        Children = [ ..Users
                            .Where(x => x != null)
                            .Select(u => new TreeItemData(new CustomTreeItemData(u.Id ?? 0, TreeNodeType.User, u.Name, ROOT_USER_NAME, u.Name, Icons.Material.Filled.Person, false, Typo.body1))
                            {
                                Children = [
                                    ..u.Account.Credits.Select(c => new TreeItemData(new CustomTreeItemData(c.Id ?? 0, TreeNodeType.Bill, $"{c.Description} : {c.Amount}", ROOT_USER_NAME, c.Description, Icons.Material.Filled.Money, false, Typo.body1))),
                                    ..u.Account.Debits.Select(d => new TreeItemData(new CustomTreeItemData(d.Id ?? 0, TreeNodeType.Bill, $"{d.Description} : {d.Amount}", ROOT_USER_NAME, d.Description, Icons.Material.Filled.Money, false, Typo.body1)))
                                    ]
                            }).ToList()
                            ]
                    }
            };
            }

            else
            {
                return new List<TreeItemData<CustomTreeItemData>>();
            }
        }
        public static List<TreeItemData<CustomTreeItemData>> GenerateSimpleUserTreeData(List<UserHeaderValue> Users)
        {
            if (Users != null)
            {
                return new List<TreeItemData<CustomTreeItemData>>()
                {
                    new TreeItemData(new CustomTreeItemData(0, TreeNodeType.Top, ROOT_USER_NAME, null, ROOT_USER_NAME, null, true, Typo.h6))
                    { 
                        Children = [
                            ..Users.Select(u => new TreeItemData(new CustomTreeItemData(0, TreeNodeType.User, u.Name, ROOT_USER_NAME, u.Name, Icons.Material.Filled.Person, false, Typo.h6))).ToList()
                        ]
                    }                 };
            }
            else
            {
                return new List<TreeItemData<CustomTreeItemData>>();
            }
        }


    }
}
