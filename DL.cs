#define MySQL
#if MySQL
using MySql.Data.MySqlClient;
using System;

namespace araba_galeri.galeri_DL
{
    internal class DL
    {
        static MySqlConnection conn = new MySqlConnection(new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            UserID = "root",
            Password = "772747581",
            Database = "araba_galeri",
        }.ConnectionString);

        public static void TestConnection()
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}
#endif