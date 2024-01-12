using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Araba_galeri_EL
{
    public class Musteri : INotifyPropertyChanged
    {
     
        
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }

            string id, ad, soy, tel, mail, tc_no, adres;
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
                    NotifyPropertyChanged("AdSoyad");
                }
            }
            public string Soyad
            {
                get => soy;
                set
                {
                    soy = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("AdSoyad");
                }
            }

            public string AdSoyad => Ad + " " + Soyad;

            public string Telefon
            {
                get => tel;
                set
                {
                    tel = value;
                    NotifyPropertyChanged();
                }
            }
            public string Mail
            {
                get => mail;
                set
                {
                    mail = value;
                    NotifyPropertyChanged();
                }
            }

            public string Adres
            {
                get => adres;
                set
                {
                    adres = value;
                    NotifyPropertyChanged();
                }
            }

        public string Tc_no
        {
            get => tc_no;
            set
            {
                tc_no = value;
                NotifyPropertyChanged();
            }
        }


    }
    }
