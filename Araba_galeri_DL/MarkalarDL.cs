using Araba_galeri_EL;
using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araba_galeri_DL
{
    public class MarkalarDL
    {
        public static bool AddContact   (Marka k, ref string message)
        {
            try
            {
                DL.OpenConnection();
                MySqlCommand command = new MySqlCommand("MarkaEkle", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@adi", k.Ad);
                command.Parameters.AddWithValue("@ulke", k.Ulke);
              


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


        public static bool EditContact(Marka k, ref string message)
        {
            try
            {
                DL.OpenConnection();

                MySqlCommand command = new MySqlCommand("MarkaGungele", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", k.ID);
                command.Parameters.AddWithValue("@adi", k.Ad);
                command.Parameters.AddWithValue("@ulke", k.Ulke);
         

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

        public static bool DeleteContact(Marka k, ref string message)
        {
            try
            {
                DL.OpenConnection();

                MySqlCommand command = new MySqlCommand("MarkaSil", DL.Connection);
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



        public static List<Marka> GetContacts(ref string message)
        {
            try
            {
                DL.OpenConnection();
                string select = "SELECT * FROM markalar ";

                MySqlCommand command = new MySqlCommand(select, DL.Connection);
                var dr = command.ExecuteReader();
                var markas = new List<Marka>();
                while (dr.Read())
                {
                    markas.Add(new Marka()
                    {
                        ID = dr["marka_Id"].ToString(),
                        Ad = dr["maeka_adi"].ToString(),
                        Ulke = dr["marka_ulkesi"].ToString(),


                    });
                }


                message = "";
                return markas;
              

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





/* MySqlCommand command = new MySqlCommand("MarkaHepsi", DL.Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                MySqlDataAdapter adp = new MySqlDataAdapter(command);
                var marks = new List<Marka>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        marks.Add(new Marka()
                        {
                            ID = reader["Marka_Id"].ToString(),
                            Ad = reader["Marka_adi"].ToString(),
                            Ulke = reader["Marka_ulke"].ToString(),

                        });
                    }
                }*/
