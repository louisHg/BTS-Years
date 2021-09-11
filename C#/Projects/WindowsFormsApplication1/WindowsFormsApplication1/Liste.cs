using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Liste : Form
    {
        private MySqlConnection connection;
        BDD bdd = new BDD();
        public Liste()
        {
            InitializeComponent();
            int listcount = bdd.nombreContainer();
            ArrayList list = new ArrayList();
            list = bdd.listbiccode();
            this.listBox1.Items.Clear();
            for (int i = 0; i < listcount; i++)
                this.listBox1.Items.Add(list[i]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int listcount = bdd.nombreContainer();
            string BIC_CODE = this.textBox5.Text;
            int zone = 0;
            if (textBox6.Text.Equals(""))
            {
                zone = 10;
            }
            else
            {
                zone = Convert.ToInt16(this.textBox6.Text);
            }
            if (BIC_CODE.Equals("") && zone == 10)
            {
                MessageBox.Show("Veuillez insérer des données");
            }
            else
            {
                ArrayList list = new ArrayList();
                list = bdd.RechercheContainer(zone, BIC_CODE);
                this.listBox1.Items.Clear();
                for (int i = 0; i < listcount; i++)
                    this.listBox1.Items.Add(list[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.connection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=test_bdd;UID=root;PASSWORD=");
                MySqlCommand commandeSQL;
                this.connection.Open();
                string biccode = listBox1.Text;
                commandeSQL = this.connection.CreateCommand();
                commandeSQL.CommandText = "SELECT Dimension, BIC_CODE, zone, x, y, z, arrive, depart, heure_arrive, heure_depart, minute_arrive, minute_depart, seconde_arrive, seconde_depart FROM container WHERE BIC_CODE = @biccode";
                commandeSQL.Parameters.AddWithValue("@biccode", biccode);
                MySqlDataReader info = commandeSQL.ExecuteReader();
                while (info.Read())
                {
                    textBox1.Text = info.GetString("zone");
                    int dim = info.GetInt16("Dimension");
                    if (dim == 20)
                    {
                        radioButton1.PerformClick();
                    }
                    else
                    {
                        radioButton2.PerformClick();
                    }
                    textBox2.Text = info.GetString("x");
                    textBox3.Text = info.GetString("y");
                    textBox4.Text = info.GetString("z");
                    label2.Text = info.GetString("BIC_CODE");
                    textBox7.Text = info.GetString("heure_arrive");
                    textBox8.Text = info.GetString("minute_arrive");
                    textBox9.Text = info.GetString("seconde_arrive");
                    textBox10.Text = info.GetString("seconde_depart");
                    textBox11.Text = info.GetString("minute_depart");
                    textBox12.Text = info.GetString("heure_depart");
                    dateTimePicker1.Value = info.GetDateTime("arrive");
                    dateTimePicker2.Value = info.GetDateTime("depart");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int zone, x, y, z, dimension;
            x = int.Parse(this.textBox2.Text);
            y = int.Parse(this.textBox3.Text);
            zone = int.Parse(this.textBox1.Text);
            z = int.Parse(this.textBox4.Text);

            if (this.radioButton1.Checked)
            {
                dimension = 20;
            }
            else dimension = 40;

            string biccode = listBox1.Text;
            bdd.DeleteContainer(biccode);
            int dimSus = bdd.SelectDimension(zone, x, y, z + 1);
            int dimSous = bdd.SelectDimension(zone, x, y, z - 1);
            if (dimSous >= dimension || (z - 1) < 0)
            {
                if (dimSus == 0)
                {
                    MessageBox.Show("Container déplacé");
                    bdd.DeleteContainer(biccode);
                }
                else MessageBox.Show("Il y a un container au dessus");
            }
            else MessageBox.Show("Container du dessous trop petit");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int listcount = bdd.nombreContainer();
            ArrayList list = new ArrayList();
            list = bdd.listbiccode();
            this.listBox1.Items.Clear();
            for (int i = 0; i < listcount; i++)
                this.listBox1.Items.Add(list[i]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                bool retard = true;
                int zone, x, y, z, dimension, Aheure, Aminute, Aseconde, Dheure, Dminute, Dseconde;
                x = int.Parse(this.textBox2.Text);
                y = int.Parse(this.textBox3.Text);
                zone = int.Parse(this.textBox1.Text);
                z = int.Parse(this.textBox4.Text);
                string biccode = listBox1.Text;

                Aheure = int.Parse(this.textBox7.Text);
                Aminute = int.Parse(this.textBox8.Text);
                Aseconde = int.Parse(this.textBox9.Text);

                Dheure = int.Parse(this.textBox12.Text);
                Dminute = int.Parse(this.textBox11.Text);
                Dseconde = int.Parse(this.textBox10.Text);
                if (this.radioButton1.Checked)
                {
                    dimension = 20;
                }
                else dimension = 40;
                DateTime arrive = dateTimePicker1.Value;
                DateTime depart = dateTimePicker2.Value;
                bdd.modifier_BDD(dimension, biccode, zone, x, y, z, arrive, depart, Aheure, Aminute, Aseconde, Dheure, Dminute, Dseconde, retard);
            }
            else
            {
                bool retard = false;
                int zone, x, y, z, dimension, Aheure, Aminute, Aseconde, Dheure, Dminute, Dseconde;
                x = int.Parse(this.textBox2.Text);
                y = int.Parse(this.textBox3.Text);
                zone = int.Parse(this.textBox1.Text);
                z = int.Parse(this.textBox4.Text);
                string biccode = listBox1.Text;

                Aheure = int.Parse(this.textBox7.Text);
                Aminute = int.Parse(this.textBox8.Text);
                Aseconde = int.Parse(this.textBox9.Text);

                Dheure = int.Parse(this.textBox12.Text);
                Dminute = int.Parse(this.textBox11.Text);
                Dseconde = int.Parse(this.textBox10.Text);
                if (this.radioButton1.Checked)
                {
                    dimension = 20;
                }
                else dimension = 40;
                DateTime arrive = dateTimePicker1.Value;
                DateTime depart = dateTimePicker2.Value;
                bdd.modifier_BDD(dimension, biccode, zone, x, y, z, arrive, depart, Aheure, Aminute, Aseconde, Dheure, Dminute, Dseconde, retard);
            }
        }
    }
}

