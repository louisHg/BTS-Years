using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace defis_cine
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
        public void Add_C(string marque, string marque_temps, string cine, string cine_film, int marque_note, string cine_freq, int cine_note)
        {
            try
            {
                if (marque_note >= 0 && marque_note <= 10 && cine_note >= 0 && cine_note <= 10)
                {
                    this.connection.Open();
                    commandeSQL.CommandText = "INSERT INTO sondage(marque,marque_temps,cine,cine_film,marque_note,cine_freq,cine_note) VALUES(@marque,@marque_temps,@cine,@cine_film,@marque_note,@cine_freq,@cine_note)";
                    commandeSQL.Parameters.AddWithValue("@marque", marque);
                    commandeSQL.Parameters.AddWithValue("@marque_temps", marque_temps);
                    commandeSQL.Parameters.AddWithValue("@cine", cine);
                    commandeSQL.Parameters.AddWithValue("@cine_film", cine_film);
                    commandeSQL.Parameters.AddWithValue("@marque_note", marque_note);
                    commandeSQL.Parameters.AddWithValue("@cine_freq", cine_freq);
                    commandeSQL.Parameters.AddWithValue("@cine_note", cine_note);
                    commandeSQL.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();

        }

        public void Add_BC(int marque_note)
        {
            MySqlCommand inserer_N = this.connection.CreateCommand(); //attribut de type MySqlCommand
            inserer_N.CommandText = "INSERT INTO sondage(marque_note) VALUES (@marque_note)"; //commande SQL pour inserer dans la table
            inserer_N.Parameters.AddWithValue("@marque_note", marque_note); //initialisation du paramètre @N avec la valeur passée en argument

            try
            {
                this.connection.Open();
                inserer_N.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }

        public ArrayList Lire_marque()
        {
            ArrayList List = new ArrayList();
            try
            {
                this.connection.Open();
                MySqlCommand lire = this.connection.CreateCommand();
                lire.CommandText = "SELECT * FROM sondage";
                MySqlDataReader Lire = lire.ExecuteReader();
                while (Lire.Read())
                {
                    List.Add(Lire.GetString("marque"));
                }
                this.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return List;
        }
        public int Lire_marquenote(String marque)
        {
            int marquenote = 0;
            try
            {
                this.connection.Open();
                MySqlCommand lire = this.connection.CreateCommand();
                lire.CommandText = "SELECT marque_note FROM sondage WHERE marque=@marque";
                lire.Parameters.AddWithValue("@marque", marque);
                MySqlDataReader Lire = lire.ExecuteReader();
                while (Lire.Read())
                {
                    marquenote = Lire.GetInt16("marque_note");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return marquenote;
            
        }
        public decimal Lire_M()
        {
            decimal val = -1;
            try
            {
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                string var_text = "SELECT AVG(marque_note) FROM sondage";
                cmd.CommandText = var_text;
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
                val = (decimal)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return val;
        }
        //lire.CommandText = "SELECT AVG(marque_note) FROM sondage";
        public decimal Lire_C()
        {
            decimal val = -1;
            try
            {
                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                string var_text = "SELECT AVG(cine_note) FROM sondage";
                cmd.CommandText = var_text;
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
                val = (decimal)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return val;
        }
        public int Lire_cinenote(String cine_film)
        {
            int cinenote = 0;
            try
            {
                this.connection.Open();
                MySqlCommand lire = this.connection.CreateCommand();
                lire.CommandText = "SELECT cine_note FROM sondage WHERE cine_film=@cine_film";
                lire.Parameters.AddWithValue("@cine_film", cine_film);
                MySqlDataReader Lire = lire.ExecuteReader();
                while (Lire.Read())
                {
                    cinenote = Lire.GetInt16("cine_note");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return cinenote;

        }
        public ArrayList Lire_cine()
        {
            ArrayList List = new ArrayList();
            try
            {
                this.connection.Open();
                MySqlCommand lire = this.connection.CreateCommand();
                lire.CommandText = "SELECT * FROM sondage";
                MySqlDataReader Lire = lire.ExecuteReader();
                while (Lire.Read())
                {
                    List.Add(Lire.GetString("cine_film"));
                }
                this.connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return List;
        }
    }
}
