using Galerie_Arta_Partea2.Models;

namespace Galerie_Arta_Partea2;

public partial class TablouPage : ContentPage
{
    Programare_vizualizare pv;
    public TablouPage(Programare_vizualizare pvizualizare)
	{
		InitializeComponent();
        pv = pvizualizare;
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var tablou = (Tablou)BindingContext;
        await App.Database.SaveTablouAsync(tablou);
        listView.ItemsSource = await App.Database.GetTablouAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var tablou = (Tablou)BindingContext;
        await App.Database.DeleteTablouAsync(tablou);
        listView.ItemsSource = await App.Database.GetTablouAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTablouAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Tablou t;
        if (listView.SelectedItem != null)
        {
            t = listView.SelectedItem as Tablou;

            var lt = new Listă_tablouri()
            {
                Programare_vizualizareID = pv.ID,
                TablouID = t.ID
            };
            await App.Database.SaveListă_tablouriAsync(lt); t.Listă_tablouri = new List<Listă_tablouri> { lt };
            await Navigation.PopAsync();
        }
    }
}