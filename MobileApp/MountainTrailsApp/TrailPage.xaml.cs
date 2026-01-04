using MountainTrailsApp.Models;

namespace MountainTrailsApp;

public partial class TrailPage : ContentPage
{
	public TrailPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var trail = (Trail)BindingContext;

        await App.Database.SaveTrailAsync(trail);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var trail = (Trail)BindingContext;

        await App.Database.DeleteTrailAsync(trail);
        await Navigation.PopAsync();
    }
}