
using Araba_galeri_EL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using araba_galeri_BL;
namespace car_gallery
{   

    public partial class carsList : ContentPage
    {

        string message = "";

        public carsList()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            if (!BL.musterisYukle(ref message))
            {
                DisplayAlert("Error", message, "Cancel");
            }

            listKisiler.ItemsSource = BL.musteris;
        }

        private async void KisiEkleEvent(object sender, EventArgs e)
        {
            carAdd page = new carAdd()
            {
                Title = "Kişi Ekle",
                AddMethod = AddKisi
            };
            await Navigation.PushModalAsync(page, true);

        }
        private async void KisiDuzenleEvent(object sender, EventArgs e)
        {
            var ib = sender as MenuItem;
            var musteri = BL.musteris.First(o => o.ID == ib.CommandParameter.ToString());
            carAdd page = new carAdd(musteri)
            {
                Title = "Kişi Düzenle",
                AddMethod = EditKisi
            };
            await Navigation.PushModalAsync(page, true);
        }

        private async void KisiSilEvent(object sender, EventArgs e)
        {
            var ib = sender as MenuItem;
            var kisi = BL.musteris.First(o => o.ID == ib.CommandParameter.ToString());

            bool answer = await DisplayAlert("Silmeyi Onayla", $"{kisi.AdSoyad} silinsin mi", "Evet", "Hayır");

            if (answer)
                //BL.Kisiler.Remove(kisi);
                if (!BL.KisiSil(kisi, ref message))
                    await DisplayAlert("Error", message, "Cancel");
        }

        private void AddKisi(Musteri musteri)
        {
            if (!BL.KisiEkle(musteri, ref message))
                DisplayAlert("Error", message, "Cancel");
        }
        private void EditKisi(Musteri musteri)
        {
            if (!BL.KisiDuzenle(musteri, ref message))
                DisplayAlert("Error", message, "Cancel");
        }

    }
}