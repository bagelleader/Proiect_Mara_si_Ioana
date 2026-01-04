using MountainTrailsApp.Models;

namespace MountainTrailsApp;

public partial class HikeLogPage : ContentPage
{
    private Trail _trail;
    public HikeLogPage(Trail trail)
    {
        InitializeComponent();
        _trail = trail;
        trailNameLabel.Text = $"Jurnal pentru: {trail.Name}";
        datePicker.Date = DateTime.Today;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        logsListView.ItemsSource = await App.Database.GetHikeLogsForTrailAsync(_trail.Id);
    }

    async void OnSaveLogClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(durationEntry.Text, out double duration))
        {
            await DisplayAlert("Eroare", "Introdu o durată validă (număr).", "OK");
            return;
        }

        var log = new HikeLog
        {
            TrailId = _trail.Id,
            Date = datePicker.Date,
            DurationHours = duration,
            Notes = notesEditor.Text
        };

        await App.Database.SaveHikeLogAsync(log);

        durationEntry.Text = string.Empty;
        notesEditor.Text = string.Empty;
        datePicker.Date = DateTime.Today;

        logsListView.ItemsSource = await App.Database.GetHikeLogsForTrailAsync(_trail.Id);
    }

    async void OnLogSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is HikeLog log)
        {
            bool delete = await DisplayAlert("Ștergere",
                "Sigur vrei să ștergi această înregistrare?",
                "Da", "Nu");

            if (delete)
            {
                await App.Database.DeleteHikeLogAsync(log);
                logsListView.ItemsSource = await App.Database.GetHikeLogsForTrailAsync(_trail.Id);
            }

            logsListView.SelectedItem = null;
        }
    }
}