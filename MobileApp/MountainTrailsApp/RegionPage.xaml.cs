using MountainTrailsApp.Models;
using TrailRegion = MountainTrailsApp.Models.Region;

namespace MountainTrailsApp;

public partial class RegionPage : ContentPage
{
    public RegionPage()
    {
        InitializeComponent();
        BindingContext = new TrailRegion(); 
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        deleteRegionBtn.IsVisible = App.CurrentUser?.Role == "Admin";

        if (App.CurrentUser == null)
        {
            await Navigation.PushAsync(new LoginPage());
            return;
        }

        regionsList.ItemsSource = await App.Database.GetRegionsAsync();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var region = (TrailRegion)BindingContext;

        await App.Database.SaveRegionAsync(region);
        regionsList.ItemsSource = await App.Database.GetRegionsAsync();

        BindingContext = new TrailRegion();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (App.CurrentUser?.Role != "Admin")
        {
            await DisplayAlert("Acces interzis", "Doar Admin poate șterge regiuni.", "OK");
            return;
        }

        var region = regionsList.SelectedItem as TrailRegion;
        if (region != null)
        {
            await App.Database.DeleteRegionAsync(region);
            regionsList.ItemsSource = await App.Database.GetRegionsAsync();

            BindingContext = new TrailRegion();
        }
    }

    void OnRegionSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            BindingContext = e.SelectedItem as TrailRegion;
        }
    }
}
