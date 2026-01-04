namespace MountainTrailsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

        }

        async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert(
                "Deconectare",
                "Sigur vrei să te deconectezi?",
                "Da",
                "Nu");

            if (!confirm)
                return;

            App.CurrentUser = null;
            Application.Current.MainPage =
                new NavigationPage(new LoginPage());
        }

    }
}
