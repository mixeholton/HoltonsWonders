using MixeWonders.Client.Components;
using MixeWonders.Values.Enums;
using MudBlazor;

namespace MixeWonders.Client.Helpers
{
    public static class DialogHelper
    {

        public static (DialogParameters<InfoDialog> Parameters, DialogOptions Options) DefaultDialogSettings(
            string ContentText,
            string OkButtonText = "Ok",
            string CancelButtonText = "Fortryd",
            Color ButtonColor = Color.Primary,
            bool CancelButtonVisible = true,
            DefaultFocusButton DefaultFocusButton = DefaultFocusButton.Cansel,
            Color TextColor = Color.Default)
        {

            DialogOptions options = new DialogOptions() { DisableBackdropClick = true };
            var parameters = new DialogParameters<InfoDialog>
        {
            { x => x.ContentText, ContentText },
            { x => x.ButtonText, OkButtonText },
            { x => x.ButtonColor, ButtonColor },
            { x => x.CancelButtonVisible, CancelButtonVisible },
            { x => x.CancelButtonText, CancelButtonText },
            { x => x.DefaultFocusButton, DefaultFocusButton}
        };

            return (parameters, options);
        }
    }
}
