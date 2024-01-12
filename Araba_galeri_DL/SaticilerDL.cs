using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Araba_galeri_EL;
namespace Araba_galeri_DL
{
    public class SaticilerDL
    {
        public static bool AddContact(Satici k, ref string message)
        {
            try
            {
                DL.OpenConnection();
                MySqlCommand command = new MySqlCommand("saticiEkle", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AD", k.Ad);
                command.Parameters.AddWithValue("@Soyad", k.Soyad);
                command.Parameters.AddWithValue("@Tc", k.Tc_no);
                command.Parameters.AddWithValue("@Telefon", k.Telefon);
                command.Parameters.AddWithValue("@Aders", k.Adres);
                command.Parameters.AddWithValue("@Epost", k.Mail);
                command.Parameters.AddWithValue("@StipiId", k.Satici_tipi_id);


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


        public static bool EditContact(Satici k, ref string message)
        {
            try
            {
                DL.OpenConnection();

                MySqlCommand command = new MySqlCommand("saticiGuncle", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Lsatici_Id", k.ID);
                command.Parameters.AddWithValue("@Lsatici_Ad", k.Ad);
                command.Parameters.AddWithValue("@Lsatici_Soyad", k.Soyad);
                command.Parameters.AddWithValue("@Lsatici_Tc", k.Tc_no);
                command.Parameters.AddWithValue("@Lsatici_Telefon", k.Telefon);
                command.Parameters.AddWithValue("@Lsatici_Eposta", k.Mail);
                command.Parameters.AddWithValue("@Lsatici_Adres", k.Adres);
                command.Parameters.AddWithValue("@Lsatici_Id", k.Satici_tipi_id);

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

        public static bool DeleteContact(Satici k, ref string message)
        {
            try
            {
                DL.OpenConnection();

                MySqlCommand command = new MySqlCommand("SaticiSil", DL.Connection);
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



        public static List<Satici> GetContacts(ref string message)
        {
            try
            {
                DL.OpenConnection();

                string select = "SELECT * FROM saticilar ";

                MySqlCommand command = new MySqlCommand(select, DL.Connection);
                var dr = command.ExecuteReader();
                var saticis = new List<Satici>();
                while (dr.Read())
                {
                    saticis.Add(new Satici()
                    {
                        ID = dr["satici_Id"].ToString(),
                        Ad = dr["satici_adi"].ToString(),
                        Soyad = dr["satici_soyad"].ToString(),
                        Tc_no = dr["satici_Tc"].ToString(),
                        Telefon = dr["satici_Telefon"].ToString(),
                        Mail = dr["satici_aders"].ToString(),
                        Adres = dr["satici_Epost"].ToString(),
                        Satici_tipi_id = dr["saticinin_tipi_Id"].ToString(),

                    });
                }

                message = "";
                return saticis;
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
    

    

