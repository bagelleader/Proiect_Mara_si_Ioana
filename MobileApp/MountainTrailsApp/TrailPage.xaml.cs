using MountainTrailsApp.Models;
using System.Linq;
using TrailRegion = MountainTrailsApp.Models.Region;

namespace MountainTrailsApp;

public partial class TrailPage : ContentPage
{
    private List<TrailRegion> _regions;
    public TrailPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var trail = (Trail)BindingContext;

        if (regionPicker.SelectedItem is TrailRegion selectedRegion)
        {
            trail.RegionID = selectedRegion.ID;
            trail.Region = selectedRegion.Name;
        }

        await App.Database.SaveTrailAsync(trail);
        await Navigation.PopAsync();
    }


    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var trail = (Trail)BindingContext;

        await App.Database.DeleteTrailAsync(trail);
        await Navigation.PopAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _regions = await App.Database.GetRegionsAsync();
        regionPicker.ItemsSource = _regions;

        if (BindingContext is Trail trail && trail.RegionID != 0)
        {
            var selected = _regions.FirstOrDefault(r => r.ID == trail.RegionID);
            if (selected != null)
            {
                regionPicker.SelectedItem = selected;
            }
        }
    }

}