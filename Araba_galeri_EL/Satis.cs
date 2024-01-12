using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Araba_galeri_EL
{
    public class Satis : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        string id, satis_id,araba_id,galeri_depozito,toplam_fiyat,satis_tarihi,musteri_Id,odeme_sekili_id,musteri_id,kalan_miktar;
        public string ID
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value; }
        }




        public string Satisid
        {
            get => satis_id;
            set
            {
                satis_id = value;
                NotifyPropertyChanged();
            }
        }

        public string Arabaid
        {
            get => araba_id;
            set
            {
                araba_id = value;
                NotifyPropertyChanged();
            }
        }
        public string Galeridepozito
        {
            get => galeri_depozito;
            set
            {
                galeri_depozito = value;
                NotifyPropertyChanged();
            }
        }
        public string Toplamfiyat
        {
            get => toplam_fiyat;
            set
            {
                toplam_fiyat = value;
                NotifyPropertyChanged();
            }
        }
        public string Satistarihi
        {
            get => satis_tarihi;
            set
            {
                satis_tarihi = value;
                NotifyPropertyChanged();
            }
        }
        public string MusteriId
        {
            get => musteri_Id;
            set
            {
                musteri_Id = value;
                NotifyPropertyChanged();
            }
        }
        public string Odemesekiliid
        {
            get => odeme_sekili_id;
            set
            {
                odeme_sekili_id = value;
                NotifyPropertyChanged();
            }
        }
        public string KalanMiktar
        {
            get => kalan_miktar;
            set
            {
                kalan_miktar = value;
                NotifyPropertyChanged();
            }
        }
    }
}

    

