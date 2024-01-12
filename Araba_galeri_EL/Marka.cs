using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Araba_galeri_EL
{
    public class Marka: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        string id, ad, ulke;
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

        public string Ad
        {
            get => ad;
            set
            {
                ad = value;
                NotifyPropertyChanged();
            }
        }
        public string Ulke
        {
            get => ulke;
            set
            {
                ulke = value;
                NotifyPropertyChanged();
            }
        }

    }
}
