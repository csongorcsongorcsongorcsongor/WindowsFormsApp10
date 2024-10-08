using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp10
{
    
    class databaseHandler
    {
        public List<sigma> sigmak = new List<sigma>();

        MySqlConnection connection;
        public databaseHandler()
        {
            string host = "localhost";
            string user = "root";
            string password = "";
            string database = "adatbazis";

            string connectionString = $"server={host};user={user};password={password};database={database}";
            connection = new MySqlConnection(connectionString);
        }
        string tableName = "skibidi";
        public void readAll()
        {
            try
            {
                connection.Open();
                string query = $"select * from {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    sigma onesigma = new sigma();
                    onesigma.id = read.GetInt32(read.GetOrdinal("id"));
                    onesigma.nev = read.GetString(read.GetOrdinal("nev"));
                    onesigma.rizzlevel = read.GetInt32(read.GetOrdinal("rizzlevel"));
                    sigmak.Add(onesigma);
                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Sikeres beolvasas");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void delOne(sigma sigma)
        {
            try
            {
                connection.Open();
                string query = $"DELETE FROM {tableName} WHERE id = {sigma.id}";
                sigmak.Remove(sigma);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Sikeres törlés");
            }
            catch (Exception e)
            {
                MessageBox.Show("Sikertelen törlés");
            }
        }
        public void addOne(sigma sigma)
        {
            try
            {
                connection.Open();
                string query = $"INSERT INTO {tableName} (nev, rizzlevel) VALUES ('{sigma.nev}','{sigma.rizzlevel}'";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                MessageBox.Show("Sikeres létrehozás");
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
    public class sigma
    {

        public int id { get; set; }
        public string nev { get; set; }
        public int rizzlevel { get; set; }
        
    }
}
