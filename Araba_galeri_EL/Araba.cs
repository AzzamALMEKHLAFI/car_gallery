using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;

namespace Araba_galeri_EL
{
    // All the code in this file is included in all platforms.
    public class Araba: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        string id, marka_Id, model, sase_no, model_yili, musteri_ID, motor_no, plaka_no, cekis,yakit_tipi,renk, satici_ID, motor_Hacmi, durum, vites,kasa_tipi;

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

        //public string Resim  => "person.png";

        public string Marka_Id
        {
            get { return marka_Id; }
            set
            {
                marka_Id = value;
                NotifyPropertyChanged();
            }
        }

       


        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                NotifyPropertyChanged();
            }
        }

       

        public string Sase_no
        {
            get { return sase_no; }
            set
            {
                sase_no = value;
                NotifyPropertyChanged();
            }
        }

        public string Model_yili
        {
            get { return model_yili; }
            set
            {
                model_yili = value;
                NotifyPropertyChanged();
            }
        }

        
            public string Musteri_ID
        {
            get { return musteri_ID; }
            set
            {
                musteri_ID = value;
                NotifyPropertyChanged();
            }
        }
        //        string id, marka_Id, model, sase_no, model_yili, musteri_ID, motor_no, plaka_no, cekis,yakit_tipi,renk, Satici_ID, Motor_Hacmi, Durum, Vites,kasa_tipi;

        public string Motor_no
        {
            get { return motor_no; }
            set
            {
                motor_no = value;
                NotifyPropertyChanged();
            }
        }
        public string Plaka_no
        {
            get { return plaka_no; }
            set
            {
                plaka_no = value;
                NotifyPropertyChanged();
            }
        }
        public string Satici_ID
        {
            get { return satici_ID; }
            set
            {
                satici_ID = value;
                NotifyPropertyChanged();
            }
        }
        public string Cekis
        {
            get { return cekis; }
            set
            {
                cekis = value;
                NotifyPropertyChanged();
            }
        }
        public string Yakit_tipi
        {
            get { return yakit_tipi; }
            set
            {
                yakit_tipi = value;
                NotifyPropertyChanged();
            }
        }

        public string Motor_Hacmi
        {
            get { return motor_Hacmi; }
            set
            {
                motor_Hacmi = value;
                NotifyPropertyChanged();
            }
        }
        public string Durum
        {
            get { return durum; }
            set
            {
                durum = value;
                NotifyPropertyChanged();
            }
        }
        
        public string Vites
        {
            get { return vites; }
            set
            {
                vites = value;
                NotifyPropertyChanged();
            }
        }
        public string Kasa_tipi
        {
            get { return kasa_tipi; }
            set
            {
                kasa_tipi = value;
                NotifyPropertyChanged();
            }
        }
    }
}