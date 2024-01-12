using Araba_galeri_EL;
using System;

namespace car_gallery
{

    public partial class saticilarD : ContentPage
    {


        public bool Result = false;
        public Satici sat = null;
        bool edit = false;
        public Action<Satici> AddMethod = null;
        public saticilarD(Satici satici=null)
        {

            InitializeComponent();
            var sel = new List<string>();
            sel.Add("Normal");
            sel.Add("Galeri");
            sel.Add("şirekt");

            Picker picker = new Picker { Title = "Sec saticinin" };
            picker.ItemsSource = sel;

            string  selectedIndex = picker.SelectedIndex.ToString();

            


            if (satici == null)
            {
                sat = new Satici();
                edit = false;
            }
            else
            {
                txtAd.Text = satici.Ad;
                txtSoy.Text = satici.Soyad;
                txtTc.Text = satici.Tc_no;
                txtTel.Text = satici.Telefon;
                txtAddr.Text = satici.Adres;
                txtMail.Text = satici.Mail;
                 satici.Satici_tipi_id = selectedIndex+1;


                sat = satici;
                edit = true;
            }
        }
            private void OKClicked(object sender, EventArgs e)
            {
                Result = true;
                sat.Ad = txtAd.Text;
                sat.Soyad = txtSoy.Text;
                sat.Tc_no = txtTc.Text;
                sat.Telefon = txtTel.Text;
                sat.Mail = txtMail.Text;
                sat.Adres = txtAddr.Text;
                 sat.Satici_tipi_id = picker.SelectedIndex.ToString()+1;

                //if (!edit)
                {
                    if (AddMethod != null)
                        AddMethod(sat);

                }

                Navigation.PopModalAsync();
            }

            private void CancelClicked(object sender, EventArgs e)
            {
                Result = false;
                Navigation.PopModalAsync();
            }
        
    }
}