using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Font = Microsoft.Maui.Font;

namespace RadinikMAUIDemo.ViewModels
{
    public partial class MainPageViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        string name;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

        }

        [RelayCommand]
        public async Task ClickMe()
        {
            // Send a message from some other module
            WeakReferenceMessenger.Default.Send(new LoggedInUserChangedMessage(new User {  Email ="Jitendra@gamil.com", EmailConfirmed= "Jitendra@gamil.com" })); Name = "You have clicked me!!";

            await Shell.Current.GoToAsync("CallsPage?id=10");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Red,
                TextColor = Colors.Green,
                ActionButtonTextColor = Colors.Yellow,
                CornerRadius = new CornerRadius(10),
                Font = Font.SystemFontOfSize(14),
                ActionButtonFont = Font.SystemFontOfSize(14),
                CharacterSpacing = 0.5
            };

            string text = "This is a Snackbar";
            string actionButtonText = "Click Here to Dismiss";
            Action action = async () => await Shell.Current.DisplayAlert("Snackbar ActionButton Tapped", "The user has tapped the Snackbar ActionButton", "OK");
            TimeSpan duration = TimeSpan.FromSeconds(3);

            try
            {
                var snackbar = Snackbar.Make(text, action, actionButtonText, duration, snackbarOptions);

                await snackbar.Show(cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {

            }
            //await Shell.Current.Navigation.PushAsync(new CallsPage(new CallsPageViewModel()), true);
        }
    }
}
