
namespace MixeWonders.Client.Helpers
{
    using MixeWonders.Client.ViewModels;
    using MixeWonders.Values.Enums;
    using MixeWonders.Values.Values;
    using MudBlazor;

    public static class TreeItemsHelper
    {
        public static string ROOT_SYSTEM_NAME = "Systemer";
        public static string ROOT_USER_NAME = "Brugere";

        public static HashSet<TreeItemData> GenerateUserCreditTreeData(List<UserValue> Users)
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
                                TreeItemChildren = u.Account.Credits.Select(b => new TreeItemData()
                                {
                                    Id = b.Id ?? 0,
                                    ParentName = u.Name,
                                    DisplayName = $"{b.Description} : {b.Amount}",
                                    Name = b.Description + " : " + b.Amount,
                                    TreeNodeType = TreeNodeType.Bill,
                                    Typography = Typo.subtitle2,
                                    Icon = Icons.Material.Filled.Money
                                }).ToHashSet().Concat(u.Account.Debits.Select(b => new TreeItemData()
                                {
                                    Id = b.Id ?? 0,
                                    ParentName = u.Name,
                                    DisplayName = $"{b.Description} : {b.Amount}",
                                    Name = b.Description + " : " + b.Amount,
                                    TreeNodeType = TreeNodeType.Bill,
                                    Typography = Typo.subtitle2,
                                    Icon = Icons.Material.Filled.Money
                                }).ToHashSet()).ToHashSet(),                                
                            }).ToHashSet()
                    }
                };
            }
            else
            {
                return new HashSet<TreeItemData>();
            }
        }public static HashSet<TreeItemData> GenerateSimpleUserTreeData(List<UserHeaderValue> Users)
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
                        TreeItemChildren = 
                        Users.Select(u => new TreeItemData()
                        {                            
                            ParentName = ROOT_USER_NAME,
                            DisplayName = u.Name,
                            Typography = Typo.h6,
                            TreeNodeType = TreeNodeType.User
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
