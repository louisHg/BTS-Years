using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        private BDD bdd;
        string BIC_CODE = "";
        int dimension = 0;
        public Form1()
        {
            InitializeComponent();
            bdd = new BDD();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            BIC_CODE = (this.textBox5.Text);
            if (this.radioButton1.Checked)
            {
                dimension = 20;
            }
            else dimension = 40;

            int zone, x, y, z;


            zone = int.Parse(this.textBox1.Text);
            if (zone < 0 || zone > 9)
            {
                label14.Text = "Zone incorrect (entre 0 et 9 !!) ";

                // MessageBox.Show("Zone incorrect ( entre 0 et 9 !!) ");
            }
            else
            { }

            x = int.Parse(this.textBox2.Text);
            if (x < 0 || x > 9)
            {
                label14.Text = "X incorrect ( entre 0 et 5 !!) ";
            }
            else
            { }

            y = int.Parse(this.textBox3.Text);
            if (y < 0 || y > 9)
            {
                label14.Text = "Y incorrect ( entre 0 et 9 !!) ";
            }
            else
            { }

            z = int.Parse(this.textBox4.Text);
            if (z < 0 || z > 9)
            {
                label14.Text = "Z incorrect ( entre 0 et 9 !!) ";
            }
            else
            { }


            bool oqp = bdd.SelectContainer(zone, x, y, z);
            bool oqp_sous=true;
            int dim=100;

            if (z > 0)
            {
                oqp_sous = bdd.SelectContainer(zone, x, y, z - 1);
                dim = bdd.SelectDimension(zone, x, y, z - 1);
            }
      
            if (!oqp && zone >= 0 && zone <= 9 && BIC_CODE != null && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
            {
                if (dim>=dimension && oqp_sous) {
                 bdd.Add_BC(dimension, BIC_CODE, zone, x, y, z);
                 label14.Text = "Container placé";
                }
                else label14.Text = "Container trop grand";

            }
            else if (!oqp || zone <= 0 || zone >= 9 || BIC_CODE != null || x <= 0 || x >= 5 || y <= 0 || y >= 9 || z <= 0 || z >= 5)
            {
                label14.Text = "valeurs incorrectes";
            }
            else
            {
                label14.Text = "Emplacement occupé";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BIC_CODE = (this.textBox5.Text);
            if (this.radioButton1.Checked)
            {
                dimension = 20;
            }
            else dimension = 40;

            int zone, x, y, z;


            zone = int.Parse(this.textBox1.Text);
            if (zone < 0 || zone > 9)
            {
                label14.Text = "Zone incorrect ( entre 0 et 9 !!) ";
            }
            else
            { }

            x = int.Parse(this.textBox2.Text);
            if (x < 0 || x > 9)
            {
                label14.Text = "X incorrect ( entre 0 et 5 !!) ";
            }
            else
            { }

            y = int.Parse(this.textBox3.Text);
            if (y < 0 || y > 9)
            {
                label14.Text = "Y incorrect ( entre 0 et 9 !!) ";
            }
            else
            { }

            z = int.Parse(this.textBox4.Text);
            if (z < 0 || z > 9)
            {
                label14.Text = "Z incorrect ( entre 0 et 9 !!) ";
            }
            else
            {}


            bool oqp = bdd.DeleteContainer(zone, x, y, z);
            if (!oqp)
            {
                bdd.Add_BC(dimension, BIC_CODE, zone, x, y, z);
                MessageBox.Show("Container déplacé");
            }
            else MessageBox.Show("Coordonnées incorrecte");
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}