using System;
using System.Collections.ObjectModel;
using System.Xml;
using Araba_galeri_DL;
using Araba_galeri_EL;

namespace araba_galeri_BL
{
    public class BL
    {
        public static ObservableCollection<Musteri> musteris = new ObservableCollection<Musteri>();
         public static bool musterisYukle(ref string message)
         {
            
             var list = MusteriDL.GetContacts(ref message);
             if (list != null)
             {
                 foreach (var k in list)
                     musteris.Add(k);

                 return true;
             }
             return false;
         }

        public static bool KisiEkle(Musteri musteri, ref string message)
        {

            if (musteri != null && MusteriDL.AddContact(musteri, ref message))
            {
                musteris.Add(musteri);
                return true;
            }

            return false;
        }

        public static bool KisiDuzenle(Musteri musteri, ref string message)
        {
            if (musteri != null && MusteriDL.EditContact(musteri, ref message))
            {
                return true;
            }

            return false;
        }
        public static bool KisiSil(Musteri musteri, ref string message)
        {
            if (musteri != null && MusteriDL.DeleteContact(musteri, ref message))
            {
                musteris.Remove(musteri);
                return true;
            }

            return false;
        }

    }
}

