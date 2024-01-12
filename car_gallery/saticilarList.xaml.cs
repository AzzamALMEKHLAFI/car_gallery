using Araba_galeri_EL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using araba_galeri_BL;
using Araba_galeri_DL;

namespace car_gallery;

public partial class saticilarList : ContentPage
{
	public saticilarList()
	{
		InitializeComponent();
        LoadData();

    }

        string message = "";

        

        private void LoadData()
        {
            if (!Satici_BL.saticiYukle(ref message))
            {
                DisplayAlert("Error", message, "Cancel");
            }

          listSaticilr.ItemsSource = Satici_BL.saticilar;
        }
      /*void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
           // kl.Text = (string)picker.ItemsSource[selectedIndex];
        }
    }*/

    private async void SaticiEkleEvent(object sender, EventArgs e)
        {
        saticilarD page = new saticilarD()
            {
                Title = "Satici Ekle",
                AddMethod = AddSatici
            };
            await Navigation.PushModalAsync(page, true);

        }
        private async void SaticiDuzenleEvent(object sender, EventArgs e)
        {
            var ib = sender as MenuItem;
            var satici = Satici_BL.saticilar.First(o => o.ID == ib.CommandParameter.ToString());
        saticilarD page = new saticilarD(satici)
            {
                Title = "Satici Düzenle",
                AddMethod = EditSatici
            };
            await Navigation.PushModalAsync(page, true);
        }

        private async void SaticiSilEvent(object sender, EventArgs e)
        {
            var ib = sender as MenuItem;
            var satici = Satici_BL.saticilar.First(o => o.ID == ib.CommandParameter.ToString());

            bool answer = await DisplayAlert("Silmeyi Onayla", $"{satici.AdSoyad} silinsin mi", "Evet", "Hayır");

            if (answer)
                //BL.Saticiler.Remove(kisi);
                if (!Satici_BL.saticiSil(satici, ref message))
                    await DisplayAlert("Error", message, "Cancel");
        }

        private void AddSatici(Satici satici)
        {
            if (!Satici_BL.saticiEkle(satici, ref message))
                DisplayAlert("Error", message, "Cancel");
        }
        private void EditSatici(Satici satici)
        {
            if (!Satici_BL.saticiDuzenle(satici, ref message))
                DisplayAlert("Error", message, "Cancel");
        }

    }
