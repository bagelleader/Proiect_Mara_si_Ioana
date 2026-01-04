using MountainTrailsApp.Models;
using System.Linq;
using System.Threading.Tasks;


namespace MountainTrailsApp;

public partial class TrailsEntryPage : ContentPage
{
    private bool _showFavoritesOnly = false;

    public TrailsEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTrailsAsync();
    }

    private async Task LoadTrailsAsync()
    {
        var trails = await App.Database.GetTrailsAsync();

        if (_showFavoritesOnly)
        {
            trails = trails.Where(t => t.IsFavorite).ToList();
        }

        trailsListView.ItemsSource = trails;
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

    async void OnToggleFavoritesClicked(object sender, EventArgs e)
    {
        _showFavoritesOnly = !_showFavoritesOnly;

        await LoadTrailsAsync();

        if (sender is ToolbarItem item)
        {
            item.Text = _showFavoritesOnly ? "Toate traseele" : "Doar favorite";
        }
    }

}