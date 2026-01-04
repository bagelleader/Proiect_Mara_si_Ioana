using MountainTrailsApp.Models;

namespace MountainTrailsApp;

public partial class TrailsEntryPage : ContentPage
{
	public TrailsEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        trailsListView.ItemsSource = await App.Database.GetTrailsAsync();
    }

    async void OnAddTrailClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TrailPage
        {
            BindingContext = new Trail()
        });
    }

    async void OnTrailSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new TrailPage
            {
                BindingContext = e.SelectedItem as Trail
            });
        }
    }
}