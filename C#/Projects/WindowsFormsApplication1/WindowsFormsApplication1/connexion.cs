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

namespace WindowsFormsApplication1
{
    public partial class connexion : Form
    {
        public ArrayList lesText;
        private BDD bdd;
        string adr = "";
        string mdp = "";
        string langue = "français";
        public connexion()
        {
            InitializeComponent();
            bdd = new BDD();
            lesText = bdd.getLangue(langue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string langue = "anglais";
            lesText = bdd.getLangue(langue);
            label4.Text = lesText[0].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string langue = "français";
            lesText = bdd.getLangue(langue);
            label4.Text = lesText[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adr = (this.textBox1.Text);
            mdp = (this.textBox2.Text);
            bool login = bdd.connect(adr, mdp);
            menu menu = new menu(lesText);
            if (login)
            {
                menu.Show();
                this.Hide();
            }
            else
            { MessageBox.Show("Identifiant ou mot de passe incorrect"); }
        }
    }
}
