using Galerie_Arta_Partea2.Models;

namespace Galerie_Arta_Partea2;

public partial class ProgramareEntryPage : ContentPage
{
	public ProgramareEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        programareView.ItemsSource = await App.Database.GetProgramare_vizualizareAsync();
    }
    async void OnProgramare_vizualizareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramarePage
        {
            BindingContext = new Programare_vizualizare()
        });
    }
    async void OnProgramareViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProgramarePage
            {
                BindingContext = e.SelectedItem as Programare_vizualizare
            });
        }
    }
}