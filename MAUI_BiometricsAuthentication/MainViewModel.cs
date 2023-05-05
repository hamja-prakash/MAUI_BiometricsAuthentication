using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Fingerprint.Abstractions;

namespace MAUI_BiometricsAuthentication
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IFingerprint _fingerprint;
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;

        public MainViewModel(IFingerprint fingerprint)
        {
            _fingerprint = fingerprint;
            FingerprintMethod();
        }

        [RelayCommand]
        async Task FingerprintMethod()
        {
            var isBiometricsAvailable = await _fingerprint.IsAvailableAsync();
            if (isBiometricsAvailable)
            {
                var dialogConfig = new AuthenticationRequestConfiguration
                ("Login using biometrics", "Confirm login with your biometrics")
                {
                    FallbackTitle = "Use Password",
                    AllowAlternativeAuthentication = true,
                };

                var result = await _fingerprint.AuthenticateAsync(dialogConfig);

                if (result.Authenticated)
                    App.Current.MainPage.Navigation.PushAsync(new TestPage());
                   // App.Current.MainPage.DisplayAlert("Access", "Biometrics Authentication successfully done.", "Ok", "Cancel");
            }
        }
    }
}
