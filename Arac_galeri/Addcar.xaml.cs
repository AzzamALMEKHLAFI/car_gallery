using Araba_galeri_EL;
namespace Arac_galeri { 
public partial class Addcar : ContentPage
{

    public bool Result = false;
    public Musteri mus = null;
    bool edit = false;
    public Action<Musteri> AddMethod = null;

    public Addcar(Musteri musteri = null)
    {

        if (musteri == null)
        {
            mus = new Musteri();
            edit = false;
        }
        else
        {
            txtAd.Text = musteri.Ad;
            txtSoy.Text = musteri.Soyad;
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