using MixeWonders.Values.Enums;
using MudBlazor;

namespace MixeWonders.Client.ViewModels
{
    public class TreeItemData
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
        public HashSet<TreeItemData>? TreeItemChildren { get; set; }
    }
}
