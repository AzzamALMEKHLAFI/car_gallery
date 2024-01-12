using Araba_galeri_EL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Araba_galeri_DL;
namespace araba_galeri_BL
{
    public class Marka_BL
    {

        public static ObservableCollection<Marka> markalar = new ObservableCollection<Marka>();
        public static bool markaYukle(ref string message)
        {

            var list = MarkalarDL.GetContacts(ref message);
            if (list != null)
            {
                foreach (var k in list)
                    markalar.Add(k);

                return true;
            }
            return false;
        }

        public static bool markaEkle(Marka marka, ref string message)
        {

            if (marka != null && MarkalarDL.AddContact(marka, ref message))
            {
                markalar.Add(marka);
                return true;
            }

            return false;
        }

        public static bool markaDuzenle(Marka satici, ref string message)
        {
            if (satici != null && MarkalarDL.EditContact(satici, ref message))
            {
                return true;
            }

            return false;
        }
        public static bool MarkaSil(Marka marka, ref string message)
        {
            if (marka != null && MarkalarDL.DeleteContact(marka, ref message))
            {
                markalar.Remove(marka);
                return true;
            }

            return false;
        }

    }
}
    

