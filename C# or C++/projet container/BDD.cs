using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace projet_container
{
    class BDD
    {
        private MySqlConnection connection;
        private MySqlCommand commandeSQL;

        private void InitConnection()
        {
            this.connection = new MySqlConnection("SERVER=XXX.X.X.X;DATABASE=theme3;UID=root;PASSWORD=");
            commandeSQL = this.connection.CreateCommand();
        }
        public BDD()
        {
            this.InitConnection();
        }



        public void Add_BC(int Dimension, string BIC_CODE, int zone, int x, int y, int z, DateTime arrive, DateTime depart, int a_heure, int a_minute, int a_seconde, int d_heure, int d_minute, int d_seconde)
        {
            try
            {
                if (zone >= 0 && zone <= 9 && BIC_CODE != null && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
                {
                    MySqlCommand commandeSQL;
                    this.connection.Open();
                    commandeSQL = this.connection.CreateCommand();
                    commandeSQL.CommandText = "INSERT INTO container(Dimension,BIC_CODE,zone,x,y,z,arrive,depart,heure_arrive,minute_arrive,seconde_arrive,heure_depart,minute_depart,seconde_depart) VALUES(@Dimension,@BIC_CODE,@zone,@x,@y,@z,@arrive,@depart,@a_heure,@a_minute,@a_seconde,@d_heure,@d_minute,@d_seconde)";
                    commandeSQL.Parameters.AddWithValue("@Dimension", Dimension);
                    commandeSQL.Parameters.AddWithValue("@BIC_CODE", BIC_CODE);
                    commandeSQL.Parameters.AddWithValue("@zone", zone);
                    commandeSQL.Parameters.AddWithValue("@x", x);
                    commandeSQL.Parameters.AddWithValue("@y", y);
                    commandeSQL.Parameters.AddWithValue("@z", z);
                    commandeSQL.Parameters.AddWithValue("@arrive", arrive);
                    commandeSQL.Parameters.AddWithValue("@depart", depart);
                    commandeSQL.Parameters.AddWithValue("@a_heure", a_heure);
                    commandeSQL.Parameters.AddWithValue("@a_minute", a_minute);
                    commandeSQL.Parameters.AddWithValue("@a_seconde", a_seconde);
                    commandeSQL.Parameters.AddWithValue("@d_heure", d_heure);
                    commandeSQL.Parameters.AddWithValue("@d_minute", d_minute);
                    commandeSQL.Parameters.AddWithValue("@d_seconde", d_seconde);
                    commandeSQL.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }
        public void modifier_BDD(int Dimension, string biccode, int zone, int x, int y, int z, DateTime arrive, DateTime depart, int Aheure, int Aminute, int Aseconde, int Dheure, int Dminute, int Dseconde, bool retard)
        {
            try
            {
                this.connection.Open();
                if (zone >= 0 && zone <= 9 && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
                {
                    if (retard == false)
                    {
                        MySqlCommand commandeSQL;
                        commandeSQL = this.connection.CreateCommand();
                        commandeSQL.CommandText = "UPDATE `container` SET Dimension = @Dimension, zone = @zone, x = @x, y = @y, z = @z, arrive = @arrive, heure_arrive = @Aheure, minute_arrive = @Aminute, seconde_arrive = @Aseconde, depart = @depart, heure_depart = @Dheure, minute_depart = @Dminute, seconde_depart = @Dseconde WHERE BIC_CODE = @biccode";
                        commandeSQL.Parameters.AddWithValue("@Dimension", Dimension);
                        commandeSQL.Parameters.AddWithValue("@biccode", biccode);
                        commandeSQL.Parameters.AddWithValue("@zone", zone);
                        commandeSQL.Parameters.AddWithValue("@x", x);
                        commandeSQL.Parameters.AddWithValue("@y", y);
                        commandeSQL.Parameters.AddWithValue("@z", z);
                        commandeSQL.Parameters.AddWithValue("@arrive", arrive);
                        commandeSQL.Parameters.AddWithValue("@depart", depart);
                        commandeSQL.Parameters.AddWithValue("@Aheure", Aheure);
                        commandeSQL.Parameters.AddWithValue("@Aminute", Aminute);
                        commandeSQL.Parameters.AddWithValue("@Aseconde", Aseconde);
                        commandeSQL.Parameters.AddWithValue("@Dheure", Dheure);
                        commandeSQL.Parameters.AddWithValue("@Dminute", Dminute);
                        commandeSQL.Parameters.AddWithValue("@Dseconde", Dseconde);
                        commandeSQL.ExecuteNonQuery();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }
        public ArrayList listbiccode()
        {
            ArrayList liste = new ArrayList(); 
            try
            {
                this.connection.Open();
                MySqlCommand commandeSQL;
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT * FROM container";

                MySqlDataReader bicread = commandeSQL.ExecuteReader();
                while (bicread.Read())
                {
                    liste.Add(bicread.GetString("BIC_CODE")); 
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return liste;
        }

        public bool connec(string adresse, string motdepasse) 
        {

            bool login = false; 
            try
            {
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT * FROM login WHERE email = @adresse and password = @motdepasse"; 
                commandeSQL.Parameters.AddWithValue("@adresse", adresse);
                commandeSQL.Parameters.AddWithValue("@motdepasse", motdepasse);

                MySqlDataReader Lire = commandeSQL.ExecuteReader();
                login = Lire.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return login;

        }

        public int SelectDimension(int zone, int x, int y, int z) // va chercher les dimensions au container en questions
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
                    dim = Lire.GetInt16("Dimension");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return dim;

        }

        public bool DetectContainer(int zone, int x, int y, int z) // regarde si zone occupé
        {

            bool oqp = false;
            try
            {
                MySqlCommand commandeSQL;
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT * FROM Container WHERE zone = @zone and x = @x and y = @y and z = @z"; 
                commandeSQL.Parameters.AddWithValue("@zone", zone);
                commandeSQL.Parameters.AddWithValue("@x", x);
                commandeSQL.Parameters.AddWithValue("@y", y);
                commandeSQL.Parameters.AddWithValue("@z", z);
                MySqlDataReader Lire = commandeSQL.ExecuteReader();
                oqp = Lire.Read();
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



        public bool DeleteContainer(string biccode)
        {
            bool efface = false;
            try
            {
                MySqlCommand commandeSQL;
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "DELETE FROM container WHERE BIC_CODE = @biccode";
                commandeSQL.Parameters.AddWithValue("@biccode", biccode);
                commandeSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return efface;

        }
        

        public int nbContainer()
        {
            int count = 0; // init var count à 0
            try
            {
                this.connection.Open();
                MySqlCommand compte_C = this.connection.CreateCommand();
                compte_C.CommandText = "SELECT COUNT(ID_container) FROM container";
                MySqlDataReader Compte = compte_C.ExecuteReader();
                while (Compte.Read())
                {
                    count = Compte.GetInt16("COUNT(ID_container)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return count;
        }

        
        
    }
}



