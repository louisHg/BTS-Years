using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    class BDD
    {
        private MySqlConnection connection;

        private void InitConnection()
        {
            MySqlCommand commandeSQL;
            this.connection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=test_bdd;UID=root;PASSWORD=");
            commandeSQL = this.connection.CreateCommand();
        }
        public BDD()
        {
            this.InitConnection();
        }
        public int nombreContainer()
        {
            int count = 0;
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

        public void Add_BC(int Dimension, string BIC_CODE, int zone, int x, int y, int z, DateTime arrive, DateTime depart, int Aheure, int Aminute, int Aseconde, int Dheure, int Dminute, int Dseconde)
        {
            try
            {
                if (zone >= 0 && zone <= 9 && BIC_CODE != null && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
                {
                    MySqlCommand commandeSQL;
                    this.connection.Open();
                    commandeSQL = this.connection.CreateCommand();
                    commandeSQL.CommandText = "INSERT INTO container(Dimension,BIC_CODE,zone,x,y,z,arrive,depart,heure_arrive,minute_arrive,seconde_arrive,heure_depart,minute_depart,seconde_depart) VALUES(@Dimension,@BIC_CODE,@zone,@x,@y,@z,@arrive,@depart,@aheure,@aminute,@aseconde,@dheure,@dminute,@dseconde)";
                    commandeSQL.Parameters.AddWithValue("@Dimension", Dimension);
                    commandeSQL.Parameters.AddWithValue("@BIC_CODE", BIC_CODE);
                    commandeSQL.Parameters.AddWithValue("@zone", zone);
                    commandeSQL.Parameters.AddWithValue("@x", x);
                    commandeSQL.Parameters.AddWithValue("@y", y);
                    commandeSQL.Parameters.AddWithValue("@z", z);
                    commandeSQL.Parameters.AddWithValue("@arrive", arrive);
                    commandeSQL.Parameters.AddWithValue("@depart", depart);
                    commandeSQL.Parameters.AddWithValue("@aheure", Aheure);
                    commandeSQL.Parameters.AddWithValue("@aminute", Aminute);
                    commandeSQL.Parameters.AddWithValue("@aseconde", Aseconde);
                    commandeSQL.Parameters.AddWithValue("@dheure", Dheure);
                    commandeSQL.Parameters.AddWithValue("@dminute", Dminute);
                    commandeSQL.Parameters.AddWithValue("@dseconde", Dseconde);
                    commandeSQL.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }

        public bool connect(string adr, string mdp)
        {
            bool login = false;
            try
            {
                MySqlCommand commandeSQL;
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT * FROM login WHERE adresse_mail = @adr and mdp = @mdp";
                commandeSQL.Parameters.AddWithValue("@adr", adr);
                commandeSQL.Parameters.AddWithValue("@mdp", mdp);
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

        public int SelectDimension(int zone, int x, int y, int z)
        {

            int dim = 0;
            try
            {
                MySqlCommand commandeSQL;
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT Dimension FROM container WHERE zone = @zone1 and x = @x1 and y = @y1 and z = @z1";
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

        public ArrayList RechercheContainer(int zone, string BIC_CODE)
        {
            ArrayList liste = new ArrayList();
            try
            {
                if (!BIC_CODE.Equals(""))
                {
                    this.connection.Open();
                    MySqlCommand commandeSQL;
                    commandeSQL = this.connection.CreateCommand();
                    commandeSQL.CommandText = "SELECT BIC_CODE FROM container WHERE BIC_CODE = @BIC_CODE";
                    commandeSQL.Parameters.AddWithValue("@BIC_CODE", BIC_CODE);

                    MySqlDataReader bicread = commandeSQL.ExecuteReader();
                    while (bicread.Read())
                    {
                        liste.Add(bicread.GetString("BIC_CODE"));
                    }
                }
                else
                {
                    this.connection.Open();
                    MySqlCommand commandeSQL;
                    commandeSQL = this.connection.CreateCommand();
                    commandeSQL.CommandText = "SELECT BIC_CODE FROM container WHERE zone = @zone";
                    commandeSQL.Parameters.AddWithValue("@zone", zone);

                    MySqlDataReader bicread = commandeSQL.ExecuteReader();
                    while (bicread.Read())
                    {
                        liste.Add(bicread.GetString("BIC_CODE"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
            return liste;

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

        public bool DetectContainer(int zone, int x, int y, int z)
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
                    else
                    {
                        MySqlCommand commandeSQL;
                        commandeSQL = this.connection.CreateCommand();
                        commandeSQL.CommandText = "UPDATE container SET depart = @depart WHERE BIC_CODE = @biccode";
                        commandeSQL.Parameters.AddWithValue("@biccode", biccode);
                        commandeSQL.Parameters.AddWithValue("@depart", depart);
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

        public ArrayList getLangue(string langue)
        {
            MySqlCommand commandeSQL;
            ArrayList list = new ArrayList();
            try
            {
                this.connection.Open();
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT " + langue + " FROM langue";
                MySqlDataReader donnees = commandeSQL.ExecuteReader();
                while (donnees.Read())
                {
                    list.Add(donnees.GetString(0));
                }
                this.connection.Close();
                commandeSQL.Parameters.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.connection.Close();
            }
            return list;
        }
    }
}