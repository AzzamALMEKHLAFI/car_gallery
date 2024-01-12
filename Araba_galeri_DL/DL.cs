#define MySQL
#if MySQL
using MySql.Data.MySqlClient;
using BsmSqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using System;
using Microsoft.Maui.Controls;
using Araba_galeri_EL;
namespace Araba_galeri_DL
{
    public class DL
    {
        static MySqlConnection conn = new MySqlConnection(new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            UserID = "root",
            Password = "772747581",
            Database = "araba_galeri",
        }.ConnectionString);

        public static MySqlConnection Connection => conn;

        public static void OpenConnection()
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }

        public static void CloseConnection()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }
    }
}
#endif