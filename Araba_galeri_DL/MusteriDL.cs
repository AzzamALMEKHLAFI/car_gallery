using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Araba_galeri_EL;

namespace Araba_galeri_DL
{
    public class MusteriDL
    {
        public static bool AddContact(Musteri k, ref string message)
        {
            try
            {
                DL.OpenConnection();
                MySqlCommand command = new MySqlCommand("MusteriEkle", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ad", k.Ad);
                command.Parameters.AddWithValue("@soyad", k.Soyad);
                command.Parameters.AddWithValue("@tc", k.Tc_no);
                command.Parameters.AddWithValue("@telefon", k.Telefon);
                command.Parameters.AddWithValue("@eposta", k.Mail);
                command.Parameters.AddWithValue("@adres", k.Adres);

                command.ExecuteNonQuery();

                message = "";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            finally
            {
                DL.CloseConnection();
            }
        
            }


        public static bool EditContact(Musteri k, ref string message)
        {
            try
            {
                DL.OpenConnection();

                MySqlCommand command = new MySqlCommand("MusteriGuncele", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Lmusteri_Id", k.ID);
                command.Parameters.AddWithValue("@Lmusteri_Ad", k.Ad);
                command.Parameters.AddWithValue("@Lmusteri_Soyad", k.Soyad);
                command.Parameters.AddWithValue("@Lmusteri_Tc", k.Tc_no);
                command.Parameters.AddWithValue("@Lmusteri_Telefon", k.Telefon);
                command.Parameters.AddWithValue("@Lmusteri_Eposta", k.Mail);
                command.Parameters.AddWithValue("@Lmusteri_Adres", k.Adres);

                command.ExecuteNonQuery();

                message = "";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            finally
            {
                DL.CloseConnection();
            }
        }

        public static bool DeleteContact(Musteri k, ref string message)
        {
            try
            {
                DL.OpenConnection();

                MySqlCommand command = new MySqlCommand("MusteriSil", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@lid", k.ID);

                command.ExecuteNonQuery();
                message = "";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            finally
            {
                DL.CloseConnection();
            }
        }



        public static List<Musteri> GetContacts(ref string message)
        {
            try
            {
                DL.OpenConnection();

                string select = "SELECT * FROM musteriler ";

                MySqlCommand command = new MySqlCommand(select, DL.Connection);
                var dr = command.ExecuteReader();
                var Musteriler = new List<Musteri>();
                while (dr.Read())
                {
                    Musteriler.Add(new Musteri()
                    {
                        ID = dr["musteri_Id"].ToString(),
                        Ad = dr["musteri_Ad"].ToString(),
                        Soyad = dr["musteri_Soyad"].ToString(),
                        Tc_no = dr["musteri_Tc"].ToString(),
                        Telefon = dr["musteri_Telefon"].ToString(),
                        Mail = dr["musteri_Eposta"].ToString(),
                        Adres = dr["musteri_Adres"].ToString(),
                    });
                }

                message = "";
                return Musteriler;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
            finally
            {
                DL.CloseConnection();
            }
        }
    }
}