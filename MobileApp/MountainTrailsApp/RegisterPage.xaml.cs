using MountainTrailsApp.Models;
using MountainTrailsApp.Security;

namespace MountainTrailsApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    async void OnCreateClicked(object sender, EventArgs e)
    {
        var email = emailEntry.Text?.Trim();
        var pass = passwordEntry.Text;
        var confirm = confirmEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
        {
            await DisplayAlert("Eroare", "Completează email și parolă.", "OK");
            return;
        }

        if (pass != confirm)
        {
            await DisplayAlert("Eroare", "Parolele nu coincid.", "OK");
            return;
        }

        var existing = await App.Database.GetUserByEmailAsync(email);
        if (existing != null)
        {
            await DisplayAlert("Eroare", "Există deja un cont cu acest email.", "OK");
            return;
        }

        var (hash, salt) = PasswordHasher.HashPassword(pass);

        var user = new User
        {
            Email = email,
            PasswordHash = hash,
            PasswordSalt = salt,
            Role = email.ToLower() == "mararogobete@gmail.com" ? "Admin" : "User"
        };

        await App.Database.SaveUserAsync(user);
        await DisplayAlert("OK", "Cont creat. Te poți autentifica.", "OK");

        await Navigation.PopAsync();
    }
}
