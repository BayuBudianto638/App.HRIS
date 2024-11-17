using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace App.HRIS.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if ((Username.Text != null) && (Password.Text != null))
        {
            if (IsCredentialCorrect(Username.Text, Password.Text))
            {
                await SecureStorage.SetAsync("hasAuth", "true");
                await Shell.Current.GoToAsync("///home");

                return;
            }
        }

        var isAvailable = await CrossFingerprint.Current.IsAvailableAsync();

        if (isAvailable)
        {
            var request = new AuthenticationRequestConfiguration
            ("Login using biometrics", "Confirm login with your biometrics");

            var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                await DisplayAlert("Authenticated!", "Access granted", "OK");
                await SecureStorage.SetAsync("hasAuth", "true");
                await Shell.Current.GoToAsync("///home");
            }
            else
            {
                await DisplayAlert("Not authenticated!", "Access denied", "OK");
            }
        }
    }

    bool IsCredentialCorrect(string username, string password)
    {
        // ganti ke BE
        return Username.Text == "admin" && Password.Text == "1234";
    }
}