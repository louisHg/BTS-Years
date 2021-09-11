using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace defis3
{
    class BDD
    {
        private MySqlConnection connection;
        private MySqlCommand commandeSQL;

        private void InitConnection()
        {
            this.connection = new MySqlConnection("SERVER=ext.epid.fr;DATABASE=gestion_containers;UID=container_user;PASSWORD=container");
            commandeSQL = this.connection.CreateCommand();
        }
        public BDD()
        {
            this.InitConnection();
        }
        public DateTime SelectDimension(string nom, string prenom, string login, string password)
        {

            int dim = 0;
            try
            {
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT Dimension FROM Container WHERE zone = @zone1 and x = @x1 and y = @y1 and z = @z1";
                commandeSQL.Parameters.AddWithValue("@zone1", zone);
                commandeSQL.Parameters.AddWithValue("@x1", x);
                commandeSQL.Parameters.AddWithValue("@y1", y);
                commandeSQL.Parameters.AddWithValue("@z1", z);
                MySqlDataReader Lire = commandeSQL.ExecuteReader();
                while (Lire.Read())
                {
                    dim = Lire.GetInt16("Dimension"); //tout ce qui correspond par rapp a la base de donnée True o
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return dim;

        }

    }
}

