using MountainTrailsApp.Security;

namespace MountainTrailsApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    async void OnLoginClicked(object sender, EventArgs e)
    {
        var email = emailEntry.Text?.Trim();
        var password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Eroare", "Completează email și parolă.", "OK");
            return;
        }

        var user = await App.Database.GetUserByEmailAsync(email);
        if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
        {
            await DisplayAlert("Eroare", "Email sau parolă incorecte.", "OK");
            return;
        }

        App.CurrentUser = user;

        Application.Current.MainPage = new AppShell();
    }

    async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}
