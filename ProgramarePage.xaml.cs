using Galerie_Arta_Partea2.Models;
using Plugin.LocalNotification;

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

        // Salvarea programării vizualizării
        await App.Database.SaveProgramare_vizualizareAsync(pvizualizare);

        // Verificarea dacă data programării este astăzi
        if (pvizualizare.Date.Date == DateTime.Now.Date)
        {
            // Programarea notificării pentru 1 secundă după salvare
            LocalNotification.Current.Show("Notificare", "Ai de vizualizat un tablou azi!", 1);
        }

        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var pvizualizare = (Programare_vizualizare)BindingContext;
        await App.Database.DeleteProgramare_vizualizareAsync(pvizualizare);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TablouPage((Programare_vizualizare)
        this.BindingContext)
        {
            BindingContext = new Tablou()
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var programarev = (Programare_vizualizare)BindingContext;
        listView.ItemsSource = await App.Database.GetListă_tablouriAsync(programarev.ID);
    }
}