using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace defis2
{
    class BDD
    {
        private MySqlConnection connection;
        private MySqlCommand commandeSQL;

        private void InitConnection()
        {
            this.connection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=theme3;UID=root;PASSWORD=");
            commandeSQL = this.connection.CreateCommand();
        }
        public BDD()
        {
            this.InitConnection();
        }
        public void Add_BC(string email, string password)
        {
            try
            {
                this.connection.Open();
                commandeSQL.CommandText = "INSERT INTO login(email,password) VALUES(@email,@password)";
                commandeSQL.Parameters.AddWithValue("@email", email);
                commandeSQL.Parameters.AddWithValue("@password", password);
                commandeSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();

        }

    }
}
    
