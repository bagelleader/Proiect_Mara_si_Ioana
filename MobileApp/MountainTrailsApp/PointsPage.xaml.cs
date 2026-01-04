using MountainTrailsApp.Models;

namespace MountainTrailsApp;

public partial class PointsPage : ContentPage
{
    private Trail _trail;

    public PointsPage(Trail trail)
    {
        InitializeComponent();
        _trail = trail;
        trailNameLabel.Text = $"Traseu: {trail.Name}";
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        pointsListView.ItemsSource = await App.Database.GetPointsForTrailAsync(_trail.Id);
    }

    async void OnAddPointClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PointPage(_trail, new PointOfInterest { TrailId = _trail.Id }));
    }

    async void OnPointSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is PointOfInterest point)
        {
            await Navigation.PushAsync(new PointPage(_trail, point));
            pointsListView.SelectedItem = null;
        }
    }
}
