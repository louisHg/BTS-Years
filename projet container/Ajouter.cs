using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
namespace projet_container
{
    public partial class Ajouter : Form
    {
        private BDD bdd;
        string BIC_CODE = "";
        int dimension = 0;
        int a_heure = 0, a_minute = 0, a_seconde = 0, d_heure = 0, d_minute = 0, d_seconde = 0;
        public Ajouter()
        {
            InitializeComponent();
            bdd = new BDD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BIC_CODE = (this.textBox2.Text);
            if (this.radioButton1.Checked)
            {
                dimension = 20;
            }
            else dimension = 40;

            int zone, x, y, z;


            zone = int.Parse(this.textBox1.Text);
            if (zone < 0 || zone > 9)
            {
                label4.Text = "Zone incorrecte (entre 0 et 9 !!) ";
            }
            

            x = int.Parse(this.textBox3.Text);
            if (x < 0 || x > 5)
            {
                label9.Text = "Emplacement incorrecte (entre 0 et 5 !!) ";
            }
            

            y = int.Parse(this.textBox4.Text);
            if (y < 0 || y > 9)
            {
                label11.Text = "Emplacement incorrecte (entre 0 et 9 !!) ";
            }
            

            z = int.Parse(this.textBox5.Text);
            if (z < 0 || z > 5)
            {
                label10.Text = "Emplacement incorrecte (entre 0 et 5 !!) ";
            }
            

            DateTime arrive = dateTimePicker1.Value;
            DateTime depart = dateTimePicker2.Value;

            a_heure = int.Parse(this.textBox11.Text);
            a_minute = int.Parse(this.textBox10.Text);
            a_seconde = int.Parse(this.textBox9.Text);

            d_heure = int.Parse(this.textBox6.Text);
            d_minute = int.Parse(this.textBox7.Text);
            d_seconde = int.Parse(this.textBox8.Text);

            bool oqp = bdd.DetectContainer(zone, x, y, z);
            if (!oqp && zone >= 0 && zone <= 9 && BIC_CODE != null && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
            {
                int dimSus = bdd.SelectDimension(zone, x, y, z + 1); //si container au dessus (z+1)
                int dimSous = bdd.SelectDimension(zone, x, y, z - 1); // si container en dessous (z-1)
                if (dimSous >= dimension || (y - 1) < 0 && dimSus == 0)
                {
                    bdd.Add_BC(dimension,BIC_CODE,zone,x,y,z,arrive,depart,a_heure,a_minute,a_seconde,d_heure,d_minute,d_seconde);
                    MessageBox.Show("Container placé");
                }
                else MessageBox.Show("Container du dessous trop petit");
            }
            else if (zone < 0 || zone > 9 || BIC_CODE == null || x < 0 || x > 5 || y < 0 || y > 9 || z < 0 || z > 5)
            {
                MessageBox.Show("Valeurs incorrectes");
            }
            else
            {
                MessageBox.Show("Emplacement occupé");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();
        }

    }
}
