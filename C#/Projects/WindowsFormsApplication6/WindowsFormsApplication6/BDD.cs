using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    class BDD
    {
        private MySqlConnection con;
        private MySqlCommand requete;
        private MySqlDataReader donnees;

        public BDD()
        {
            this.InitConnection();
        }

        private void InitConnection()
        {
            this.con = new MySqlConnection("SERVER=ext.epid.fr;DATABASE=gestion_containers;UID=container_user;PASSWORD=container");
            this.requete = this.con.CreateCommand();
        }

        public ArrayList Lire_BC(string Date)
        {
            ArrayList List = new ArrayList();
            try
            {
                this.con.Open();
                this.requete.CommandText = "SELECT * FROM personne where prenom=@date";
                this.requete.Parameters.AddWithValue("@date", Date);
                donnees = this.requete.ExecuteReader();
                while (donnees.Read())
                {
                    ArrayList t = new ArrayList();
                    t.Add(donnees.GetString("nom"));
                    t.Add(donnees.GetString("prenom"));
                    t.Add(donnees.GetString("login"));
                    t.Add(donnees.GetString("password"));
                    List.Add(t);
                }
                this.requete.Parameters.Clear();
                this.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }
            return List;
        }

        public void Add_N(string Dimension, string BIC_CODE)
        {
            try
            {
                this.con.Open();
                MySqlCommand inserer_N = this.con.CreateCommand();
                inserer_N.CommandText = "INSERT INTO personne(adresse_mail,password) VALUES(@login,@password)";
                inserer_N.Parameters.AddWithValue("@login", Dimension);
                inserer_N.Parameters.AddWithValue("@password", BIC_CODE);
                inserer_N.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.con.Close();
        }

        public ArrayList Lire()
        {
            ArrayList List = new ArrayList();
            try
            {
                this.con.Open();
                this.requete.CommandText = "SELECT * FROM personne";
                donnees = this.requete.ExecuteReader();
                while (donnees.Read())
                {
                    ArrayList t = new ArrayList();
                    t.Add(donnees.GetString("nom"));
                    t.Add(donnees.GetString("prenom"));
                    t.Add(donnees.GetString("login"));
                    t.Add(donnees.GetString("password"));
                    t.Add(donnees.GetString("id_personne"));
                    List.Add(t);
                }
                this.requete.Parameters.Clear();
                this.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }
            return List;
        }

        public void update(string mdp, string id)
        {
            try
            {
                this.con.Open();
                MySqlCommand update = this.con.CreateCommand();
                update.CommandText = "UPDATE personne SET password=MD5('@password') where id_personne=@n";
                update.Parameters.AddWithValue("@password", mdp);
                update.Parameters.AddWithValue("@n", id);
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.con.Close();
            this.requete.Parameters.Clear();
        }
        public void delete_container(string x)
        {
            try
            {
                this.con.Open();
                MySqlCommand delete = this.con.CreateCommand();
                delete.CommandText = "DELETE FROM personne WHERE nom = @nom";
                delete.Parameters.AddWithValue("@nom", x);
                delete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.con.Close();
        }
        public void Add_N(string Dimension, string BIC_CODE, string X, string Y)
        {
            try
            {
                this.con.Open();
                MySqlCommand inserer_N = this.con.CreateCommand();
                inserer_N.CommandText = "INSERT INTO personne(nom,prenom,login,password) VALUES(@login,@password,@nom,@password)";
                inserer_N.Parameters.AddWithValue("@login", Dimension);
                inserer_N.Parameters.AddWithValue("@password", BIC_CODE);
                inserer_N.Parameters.AddWithValue("@nom", X);
                inserer_N.Parameters.AddWithValue("@password", Y);
                inserer_N.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.con.Close();
        }
    }
}
