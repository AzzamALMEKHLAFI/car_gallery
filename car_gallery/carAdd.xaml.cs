using Araba_galeri_EL;
namespace car_gallery
{
    public partial class carAdd : ContentPage
    {

        public bool Result = false;
        public Musteri mus = null;
        bool edit = false;
        public Action<Musteri> AddMethod = null;

        public carAdd(Musteri musteri = null)
        {
            InitializeComponent();

            if (musteri == null)
            {
                mus = new Musteri();
                edit = false;
            }
            else
            {
                txtAd.Text = musteri.Ad;
                txtSoy.Text = musteri.Soyad;
                txtTc.Text = musteri.Tc_no;

                txtTel.Text = musteri.Telefon;
                txtMail.Text = musteri.Mail;
                txtAddr.Text = musteri.Adres;
                mus = musteri;
                edit = true;
            }
        }
        private void OKClicked(object sender, EventArgs e)
        {
            Result = true;
            mus.Ad = txtAd.Text;
            mus.Soyad = txtSoy.Text;
            mus.Tc_no = txtTc.Text;
            mus.Telefon = txtTel.Text;
            mus.Mail = txtMail.Text;
            mus.Adres = txtAddr.Text;

            //if (!edit)
            {
                if (AddMethod != null)
                    AddMethod(mus);

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