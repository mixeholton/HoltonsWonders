using MixeWonders.Values.Enums;
using MudBlazor;

namespace MixeWonders.Client.ViewModels
{
    public class CustomTreeItemData
    {
        public int Id { get; set; }
        public TreeNodeType TreeNodeType { get; set; }
        public string? DisplayName { get; set; }
        /// <summary>
        /// Navn på ejeren af noden (Modul)
        /// </summary>
        public string? ParentName { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public bool IsExpanded { get; set; } = true;
        public Typo Typography { get; set; }
        public CustomTreeItemData(int id, TreeNodeType type, string displayName, string? parentName, string? name, string?icon, bool Expanded, Typo typography) 
        { 
            Id = id;
            TreeNodeType = type;
            DisplayName = displayName;
            ParentName = parentName;
            Name = name;
            Icon = icon;
            Typography = typography;
        }


    }
    public class TreeItemData : TreeItemData<CustomTreeItemData>
    {        
        public TreeItemData(CustomTreeItemData itemData) : base(itemData) 
        { 
            Text = itemData.DisplayName;
            Value = itemData;
            Icon = itemData.Icon;
        }
    }
}
