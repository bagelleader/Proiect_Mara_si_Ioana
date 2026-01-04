using MountainTrailsApp.Models;

namespace MountainTrailsApp;

public partial class PointPage : ContentPage
{
    private Trail _trail;

    public PointPage(Trail trail, PointOfInterest point)
    {
        InitializeComponent();
        _trail = trail;
        BindingContext = point;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        var point = (PointOfInterest)BindingContext;

        if (string.IsNullOrWhiteSpace(point.Name))
        {
            await DisplayAlert("Eroare", "Completează numele punctului.", "OK");
            return;
        }

        await App.Database.SavePointAsync(point);
        await Navigation.PopAsync();
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (App.CurrentUser?.Role != "Admin")
        {
            await DisplayAlert("Acces interzis", "Doar Admin poate șterge puncte de interes.", "OK");
            return;
        }

        var point = (PointOfInterest)BindingContext;

        if (point.Id != 0)
            await App.Database.DeletePointAsync(point);

        await Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}
