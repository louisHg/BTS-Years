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
    public partial class connexion : Form
    {
        private BDD bdd;
        string adresse = "";
        string motdepasse = "";
        public connexion()
        {
            InitializeComponent();
            bdd = new BDD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adresse = (this.textBox1.Text);
            
            motdepasse = (this.textBox2.Text);
            bool login = bdd.connec(adresse, motdepasse);
            menu menu = new menu();
            if (login)
            {
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Containers";
            label2.Text = "Interface de connexion";
            label3.Text = "Email";
            label4.Text = "Mot de passe";
            button1.Text = "Connexion";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Containers";
            label2.Text = "Connection interface ";
            label3.Text = "Email";
            label4.Text = "password";
            button1.Text = "Connection";
        }

       
    }
}
