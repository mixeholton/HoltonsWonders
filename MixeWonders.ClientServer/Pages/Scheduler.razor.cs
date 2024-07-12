using MixeWonders.Client.Helpers;
using MixeWonders.Client.ViewModels;
using MixeWonders.Values.Enums;
using MudBlazor;

namespace MixeWonders.ClientServer.Pages
{
    public partial class Scheduler
    {
        public List<DropItem> _items { get; set; }
        public List<DropItem> _FolderItems { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan Interval { get; set; }
        public int NumOfCols { get; set; } = 0;

        protected async override Task OnInitializedAsync()
        {
            EndTime = new TimeSpan(24, 0, 0);
            StartTime = new TimeSpan(8, 0, 0);            
            Interval = new TimeSpan(0, 5, 0);            

            _items = TimeblockSchedulerHelper.GetDropItems(TimeSpan.FromMinutes(5));
            _FolderItems = TimeblockSchedulerHelper.GetDropFolderItems();
            StateHasChanged();

        }

        private void ItemUpdated(MudItemDropInfo<DropItem> dropItem)
        {
            if(dropItem.Item.Identifier == "default" && dropItem.DropzoneIdentifier != "default")
            {
                
                WeekDay weekday;
                Enum.TryParse(dropItem.DropzoneIdentifier.Split(' ')[1], out weekday);
                _items.Add(new DropItem() { Color = dropItem.Item.Color, Identifier = dropItem.DropzoneIdentifier, Icon = dropItem.Item.Icon, Day = weekday});
            }
            else
            {
                dropItem.Item.Identifier = dropItem.DropzoneIdentifier;
            }
            StateHasChanged();
        }
    }
}
