using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication5
{
    class BDD
    {
        private MySqlConnection connection;
        private MySqlCommand commandeSQL;

        private void InitConnection()
        {
            this.connection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=cont;UID=root;PASSWORD=");
            commandeSQL = this.connection.CreateCommand();
        }
        public BDD()
        {
            this.InitConnection();
        }
        public void Add_BC(int Dimension, string BIC_CODE, int zone, int x, int y, int z)
        {
            try
            {
                if (zone >= 0 && zone <= 9 && BIC_CODE != null && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
                {
                    this.connection.Open();
                    commandeSQL.CommandText = "INSERT INTO Container(Dimension,BIC_CODE,zone,x,y,z) VALUES(@Dimension,@BIC_CODE,@zone,@x,@y,@z)";
                    commandeSQL.Parameters.AddWithValue("@Dimension", Dimension);
                    commandeSQL.Parameters.AddWithValue("@BIC_CODE", BIC_CODE);
                    commandeSQL.Parameters.AddWithValue("@zone", zone);
                    commandeSQL.Parameters.AddWithValue("@x", x);
                    commandeSQL.Parameters.AddWithValue("@y", y);
                    commandeSQL.Parameters.AddWithValue("@z", z);
                    commandeSQL.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }



        public int SelectDimension(int zone, int x, int y, int z)
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
                while (Lire.Read()) {
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

        public bool DetectContainer(int zone, int x, int y, int z) // detect si container à l'emplacement

        {

            bool oqp = false;
            try
            {
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT ID_container FROM Container WHERE zone = @zone1 and x = @x1 and y = @y1 and z = @z1";
                commandeSQL.Parameters.AddWithValue("@zone1", zone);
                commandeSQL.Parameters.AddWithValue("@x1", x);
                commandeSQL.Parameters.AddWithValue("@y1", y);
                commandeSQL.Parameters.AddWithValue("@z1", z);

                MySqlDataReader Lire = commandeSQL.ExecuteReader();
                oqp = Lire.Read(); //tout ce qui correspond par rapp a la base de donnée True o
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return oqp;

        }

        public bool SelectContainer(int zone, int x, int y, int z)
        {
            
            bool oqp = false;
            try
            {          
                    this.connection.Open();
                    commandeSQL = this.connection.CreateCommand();
                    commandeSQL.CommandText = "SELECT ID_container FROM Container WHERE zone = @zone1 and x = @x1 and y = @y1 and z = @z1";
                    commandeSQL.Parameters.AddWithValue("@zone1", zone);
                    commandeSQL.Parameters.AddWithValue("@x1", x);
                    commandeSQL.Parameters.AddWithValue("@y1", y);
                    commandeSQL.Parameters.AddWithValue("@z1", z);

                    MySqlDataReader Lire = commandeSQL.ExecuteReader();
                    oqp = Lire.Read(); //tout ce qui correspond par rapp a la base de donnée True o
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return oqp;

        }
        
        
        
        
        public bool DeleteContainer(int zone, int x, int y, int z)
        {
            bool efface = false;
            try
            {
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "DELETE FROM Container WHERE zone = @zone and x = @x and y = @y and z = @z";
                commandeSQL.Parameters.AddWithValue("@zone", zone);
                commandeSQL.Parameters.AddWithValue("@x", x);
                commandeSQL.Parameters.AddWithValue("@y", y);
                commandeSQL.Parameters.AddWithValue("@z", z);
                commandeSQL.ExecuteNonQuery();
                      

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return efface;

        }
    }
}



