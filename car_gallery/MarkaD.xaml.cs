using Araba_galeri_EL;

namespace car_gallery {

    public partial class MarkaD : ContentPage
    {
        public bool Result = false;
        public Marka mus = null;
        bool edit = false;
        public Action<Marka> AddMethod = null;
        public MarkaD(Marka marka = null)
        {
            InitializeComponent();

            if (marka == null)
            {
                mus = new Marka();
                edit = false;
            }
            else
            {
                txtmarkaadi.Text = marka.Ad;
                txtulke.Text = marka.Ulke;

                mus = marka;
                edit = true;
            }
        }

            private void OKClicked(object sender, EventArgs e)
            {
                Result = true;
                mus.Ad = txtmarkaadi.Text;
                mus.Ulke = txtulke.Text;


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