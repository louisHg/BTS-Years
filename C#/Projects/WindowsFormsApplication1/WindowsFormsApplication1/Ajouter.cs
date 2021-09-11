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
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Ajouter : Form
    {
        private BDD bdd;
        string BIC_CODE = "";
        int dimension = 0;
        int Aheure = 0, Aminute = 0, Aseconde = 0, Dheure = 0, Dminute = 0, Dseconde = 0;
        public Ajouter()
        {
            InitializeComponent();
            bdd = new BDD();
        }

        private void button1_Click(object sender, EventArgs e)
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
                label11.Text = "Zone incorrecte (entre 0 et 9 !!) ";
            }
            else
            { }

            x = int.Parse(this.textBox3.Text);
            if (x < 0 || x > 5)
            {
                label12.Text = "Emplacement incorrecte (entre 0 et 5 !!) ";
            }
            else
            { }

            y = int.Parse(this.textBox4.Text);
            if (y < 0 || y > 9)
            {
                label13.Text = "Emplacement incorrecte (entre 0 et 9 !!) ";
            }
            else
            { }

            z = int.Parse(this.textBox5.Text);
            if (z < 0 || z > 5)
            {
                label14.Text = "Emplacement incorrecte (entre 0 et 5 !!) ";
            }
            else
            { }

            DateTime arrive = dateTimePicker1.Value;
            DateTime depart = dateTimePicker2.Value;

            Aheure = int.Parse(this.textBox1.Text);
            Aminute = int.Parse(this.textBox2.Text);
            Aseconde = int.Parse(this.textBox3.Text);

            Dheure = int.Parse(this.textBox7.Text);
            Dminute = int.Parse(this.textBox6.Text);
            Dseconde = int.Parse(this.textBox4.Text);

            bool oqp = bdd.DetectContainer(zone, x, y, z);
            if (!oqp && zone >= 0 && zone <= 9 && BIC_CODE != null && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
            {
                int dimSus = bdd.SelectDimension(zone, x, y, z + 1);
                int dimSous = bdd.SelectDimension(zone, x, y, z - 1);
                if (dimSous >= dimension || (z - 1) < 0 && dimSus == 0)
                {
                    bdd.Add_BC(dimension, BIC_CODE, zone, x, y, z, arrive, depart, Aheure, Aminute, Aseconde, Dheure, Dminute, Dseconde);
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
            foreach (var box in groupBox1.Controls.OfType<RadioButton>())
            {
                box.Checked = false;
            }

        }
        /*BIC_CODE = (this.textBox5.Text);
            

        int zone, x, y, z;


        zone = int.Parse(this.textBox8.Text);
        if (zone < 0 || zone > 9)
        {
            label9.Text = "Zone incorrecte (entre 0 et 9 !!) ";
        }
        else
        { }

            
        if (x < 0 || x > 9)
        {
            label13.Text = "X incorrect ( entre 0 et 5 !!) ";
        }
        else
        { }

        y = int.Parse(this.textBox10.Text);
        if (y < 0 || y > 9)
        {
            label14.Text = "Zone incorrecte (entre 0 et 9 !!) ";
        }
        else
        { }

        z = int.Parse(this.textBox11.Text);
        if (z < 0 || z > 9)
        {
            label16.Text = "Zone incorrecte (entre 0 et 5 !!) ";
        }
        else
        { }


        bool oqp = bdd.DeleteContainer(zone, x, y, z);
        if (!oqp && zone >= 0 && zone <= 9 && BIC_CODE != null && x >= 0 && x <= 5 && y >= 0 && y <= 9 && z >= 0 && z <= 5)
        {
                
            }    
        }
        else MessageBox.Show("Coordonnées incorrecte");
    */

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox8.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox9.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox10.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox11.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox1.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox2.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox3.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox7.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox6.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                if (Regex.IsMatch(textBox4.Text, "\\D+"))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        public void language_Ajouter(string langue)
        {
            if (langue == "anglais")
            {

            }
        }
    }
}