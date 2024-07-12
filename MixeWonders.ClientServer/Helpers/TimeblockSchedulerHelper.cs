using MixeWonders.Client.ViewModels;
using MixeWonders.ClientServer.Components;
using MixeWonders.Values.Enums;
using MudBlazor;

namespace MixeWonders.Client.Helpers
{
    public static class TimeblockSchedulerHelper
    {
        private static TimeSpan EndTime => new TimeSpan(24, 0, 0);
        private static readonly List<TimeSpan> _acceptedTimeIntervals = new List<TimeSpan>()
        {
            new TimeSpan(0, 5, 0),
            new TimeSpan(0, 10, 0),
            new TimeSpan(0, 15, 0),
            new TimeSpan(0, 20, 0),
            new TimeSpan(0, 30, 0),
            new TimeSpan(0, 45, 0),
            new TimeSpan(0, 60, 0),
            new TimeSpan(0, 120, 0),
            new TimeSpan(0, 180, 0),
            new TimeSpan(0, 240, 0),
            new TimeSpan(1, 0, 0),
            new TimeSpan(2, 0, 0),
            new TimeSpan(3, 0, 0),
            new TimeSpan(4, 0, 0),
        };


        public static List<DropItem> GetDropItems(TimeSpan intervalBetweenItems)
        {
            if (!_acceptedTimeIntervals.Contains(intervalBetweenItems))
            {
                return new List<DropItem>();
            }
            var identifierCount = new TimeSpan(8,0,0);
            var value = new List<DropItem>()
            { 
                new DropItem() { Icon = @Icons.Custom.Uncategorized.ChessPawn, Color = Color.Primary, Day = WeekDay.Monday, Identifier = $"{identifierCount} {WeekDay.Monday}" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.ChessPawn, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = $"{identifierCount.Add(new TimeSpan(9, 0, 0))} {WeekDay.Monday}" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.ChessPawn, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = $"{identifierCount.Add(new TimeSpan(9, 30, 0))} {WeekDay.Monday}" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.ChessPawn, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = $"{identifierCount.Add(new TimeSpan(10, 0, 0))} {WeekDay.Monday}" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.ChessPawn, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = $"{identifierCount.Add(new TimeSpan(11, 0, 0))} {WeekDay.Monday}" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.ChessPawn, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = $"{identifierCount.Add(new TimeSpan(12, 0, 0))} {WeekDay.Monday}" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.WaterMelon, Color = Color.Primary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.BioHazard, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.Backpack, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.Girl, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.Boy, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.DatasetLinked, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" }
            };

            return value;
        }
        public static List<DropItem> GetDropFolderItems()
        {
            
            var value = new List<DropItem>()
            { 
                new DropItem() { Icon = @Icons.Custom.Uncategorized.WaterMelon, Color = Color.Primary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Custom.Uncategorized.BioHazard, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.Backpack, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.Girl, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.Boy, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" },
                new DropItem() { Icon = @Icons.Material.Filled.DatasetLinked, Color = Color.Secondary, Day = WeekDay.Monday, Identifier = "default" }
            };

            return value;
        }


    }
}
