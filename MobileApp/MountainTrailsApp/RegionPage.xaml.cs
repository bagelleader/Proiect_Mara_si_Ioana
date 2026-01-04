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
