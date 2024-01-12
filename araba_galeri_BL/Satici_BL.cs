using Araba_galeri_DL;
using Araba_galeri_EL;
using System.Collections.ObjectModel;
namespace araba_galeri_BL
{
    public class Satici_BL
    {
        public static ObservableCollection<Satici> saticilar = new ObservableCollection<Satici>();
        public static bool saticiYukle(ref string message)
        {

            var list = SaticilerDL.GetContacts(ref message);
            if (list != null)
            {
                foreach (var k in list)
                    saticilar.Add(k);

                return true;
            }
            return false;
        }

        public static bool saticiEkle(Satici satici, ref string message)
        {

            if (satici != null && SaticilerDL.AddContact(satici, ref message))
            {
                saticilar.Add(satici);
                return true;
            }

            return false;
        }

        public static bool saticiDuzenle(Satici satici, ref string message)
        {
            if (satici != null && SaticilerDL.EditContact(satici, ref message))
            {
                return true;
            }

            return false;
        }
        public static bool saticiSil(Satici satici, ref string message)
        {
            if (satici != null && SaticilerDL.DeleteContact(satici, ref  message))
            { 
                saticilar.Remove(satici);
                return true;
            }

            return false;
          }

    }
}
    

