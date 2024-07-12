using MixeWonders.Values.Enums;
using MudBlazor;

namespace MixeWonders.Client.ViewModels
{
    public class DropItem
    {
        public string Icon { get; init; }
        public Color Color { get; init; }
        public string Identifier { get; set; }
        public WeekDay Day { get; set; }
    }
}
