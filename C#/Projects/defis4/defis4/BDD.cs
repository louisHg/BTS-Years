using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace defis4
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
        public void Add_BC(string nom, string prenom, string login, string password, DateTime time)
        {
            try
            {
                this.connection.Open();
                commandeSQL.CommandText = "INSERT INTO personne(nom,prenom,login,password,date) VALUES(@nom,@prenom,@login,@password,@time)";
                commandeSQL.Parameters.AddWithValue("@nom", nom);
                commandeSQL.Parameters.AddWithValue("@prenom", prenom);
                commandeSQL.Parameters.AddWithValue("@login", login);
                commandeSQL.Parameters.AddWithValue("@password", password);
                commandeSQL.Parameters.AddWithValue("@time", time);
                commandeSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();

        }
        public void Add_N(string password)
        {
            try 
            {
                this.connection.Open();
                commandeSQL.CommandText = "INSERT INTO personne(password) VALUES(@password)";
                commandeSQL.CommandText = "SELECT MD5('test')";
            }
        }
        
 

    }
}