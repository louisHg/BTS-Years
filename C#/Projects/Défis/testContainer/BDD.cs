using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace testContainer
{
    class BDD
    {
        private MySqlConnection con;
        private MySqlCommand requete;
        private MySqlDataReader donnees;

        public BDD()
        {
            this.InitConnexion();
        }
        private void InitConnexion()
        {
            //     this.con = new MySqlConnection("SERVER=127.0.0.1;DATABASE=gestion_containers;UID=root;PASSWORD=");
            this.con = new MySqlConnection("SERVER=ext.epid.fr;DATABASE=gestion_containers;UID=container_user;PASSWORD=container");
            this.requete = this.con.CreateCommand();
        }
        public ArrayList getPersonnes()
        {
            ArrayList list = new ArrayList();
            try
            {
                this.con.Open();
                this.requete.CommandText = "SELECT id_personne,nom,prenom, login,password FROM personne";
                donnees = this.requete.ExecuteReader();
                while (donnees.Read())
                {
                    ArrayList t = new ArrayList();
                    t.Add(donnees.GetInt16("id_personne"));
                    t.Add(donnees.GetString("nom"));
                    t.Add(donnees.GetString("prenom"));
                    t.Add(donnees.GetString("login"));
                    t.Add(donnees.GetString("password"));
                    list.Add(t);
                }
                this.con.Close();
                this.requete.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }

            return list;
        }
        public void setPersonne(string nom, string prenom, string login, string password)
        {
            try
            {
                this.con.Open();
                requete = this.con.CreateCommand();
                requete.CommandText = "INSERT INTO personne(nom,prenom,login,password) VALUES (@nom,@prenom,@login,MD5(@password))";
                requete.Parameters.AddWithValue("@nom", nom);
                requete.Parameters.AddWithValue("@prenom", prenom);
                requete.Parameters.AddWithValue("@login", login);
                requete.Parameters.AddWithValue("@password", password);
                requete.ExecuteNonQuery();
                this.con.Close();
                this.requete.Parameters.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }
        }
        public void changerMdp(String login,String mdp)
        {
            try
            {
                this.con.Open();
                requete = this.con.CreateCommand();
                requete.CommandText = "UPDATE personne SET password=MD5(@password) where login=@login";
                requete.Parameters.AddWithValue("@password", mdp);
                requete.Parameters.AddWithValue("@login", login);
                requete.ExecuteNonQuery();
                this.con.Close();
                this.requete.Parameters.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }
        }
        public string chercherIntrus(DateTime date)
        {
            string login = "";
            try
            {
                this.con.Open();
                this.requete.CommandText = "SELECT id_personne,nom,prenom, login,password FROM personne where date=@date";
                requete.Parameters.AddWithValue("@date", date);
                donnees = this.requete.ExecuteReader();
                if (donnees.Read())
                {
                    login = donnees.GetString("login");
                }
                this.con.Close();
                this.requete.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }

            return login;
        }
        public ArrayList getMessages()
        {
            ArrayList list = new ArrayList();
            try
            {
                this.con.Open();
                this.requete.CommandText = "SELECT id_personne, id_destinataire, texteMessage,date FROM message ORDER BY date";
                donnees = this.requete.ExecuteReader();
                while (donnees.Read())
                {
                    ArrayList t = new ArrayList();
                    t.Add(donnees.GetInt16("id_personne"));
                    t.Add(donnees.GetInt16("id_destinataire"));
                    t.Add(donnees.GetString("texteMessage"));
                    t.Add(donnees.GetString("date"));
                    list.Add(t);
                }
                this.con.Close();
                this.requete.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }

            return list;
        }

        public ArrayList getMesMessages(int id)
        {
            ArrayList list = new ArrayList();
            try
            {
                this.con.Open();
                this.requete.CommandText = "SELECT id_personne, id_destinataire, texteMessage,date FROM message where id_destinataire=@id ORDER BY date";
                this.requete.Parameters.AddWithValue("@id",id);
                donnees = this.requete.ExecuteReader();
                while (donnees.Read())
                {
                    ArrayList t = new ArrayList();
                    t.Add(donnees.GetInt16("id_personne"));
                    t.Add(donnees.GetInt16("id_destinataire"));
                    t.Add(donnees.GetString("texteMessage"));
                    t.Add(donnees.GetString("date"));
                    list.Add(t);
                }
                this.con.Close();
                this.requete.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.con.Close();
            }

            return list;
        }

    }
}
