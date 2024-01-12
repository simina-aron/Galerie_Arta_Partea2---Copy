using Galerie_Arta_Partea2.Models;

namespace Galerie_Arta_Partea2;

public partial class ProgramarePage : ContentPage
{
	public ProgramarePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var pvizualizare = (Programare_vizualizare)BindingContext;
        pvizualizare.Date = DateTime.UtcNow;
        await App.Database.SaveProgramare_vizualizareAsync(pvizualizare);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var pvizualizare = (Programare_vizualizare)BindingContext;
        await App.Database.DeleteProgramare_vizualizareAsync(pvizualizare);
        await Navigation.PopAsync();
    }
}