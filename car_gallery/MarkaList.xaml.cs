
using Araba_galeri_EL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using araba_galeri_BL;

namespace car_gallery
{

    public partial class MarkaList : ContentPage
    {

        string message = "";

        public MarkaList()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            if (!Marka_BL.markaYukle(ref message))
            {
                DisplayAlert("Error", message, "Cancel");
            }

            listmarka.ItemsSource = Marka_BL.markalar;
        }

        private async void MarkaEkleEvent(object sender, EventArgs e)
        {
            MarkaD page = new MarkaD()
            {
                Title = "Marka Ekle",
                AddMethod = AddMarka
            };
            await Navigation.PushModalAsync(page, true);

        }
        private async void MarkaDuzenleEvent(object sender, EventArgs e)
        {
            var ib = sender as MenuItem;
            var marka = Marka_BL.markalar.First(o => o.ID == ib.CommandParameter.ToString());
            MarkaD page = new MarkaD(marka)
            {
                Title = "Marka Düzenle",
                AddMethod = EditMarka
            };
            await Navigation.PushModalAsync(page, true);
        }

        private async void MarkaSilEvent(object sender, EventArgs e)
        {
            var ib = sender as MenuItem;
            var mar = Marka_BL.markalar.First(o => o.ID == ib.CommandParameter.ToString());

            bool answer = await DisplayAlert("Silmeyi Onayla", $"{mar.Ad} silinsin mi", "Evet", "Hayır");

            if (answer)
                //BL.Kisiler.Remove(kisi);
                if (!Marka_BL.MarkaSil(mar, ref message))
                    await DisplayAlert("Error", message, "Cancel");
        }

        private void AddMarka(Marka marka)
        {
            if (!Marka_BL.markaEkle(marka, ref message))
                DisplayAlert("Error", message, "Cancel");
        }
        private void EditMarka(Marka marka)
        {
            if (!Marka_BL.markaDuzenle(marka, ref message))
                DisplayAlert("Error", message, "Cancel");
        }

    }

}

















