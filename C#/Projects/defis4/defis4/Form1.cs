using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace defis4
{
    public partial class Form1 : Form
    {
        private BDD bdd;
        public Form1()
        {
            InitializeComponent();
            bdd = new BDD();
        }

        private void button1_Click(object sender, EventArgs e) //créer
        {
            DateTime time = new DateTime();
            time = DateTime.Now;
            string nom, prenom, login, password;
            nom = textBox1.Text;
            prenom = textBox2.Text;
            login = textBox3.Text;
            password = textBox4.Text;
            bdd.Add_BC(nom, prenom, login, password, time);
        }

        private void button2_Click(object sender, EventArgs e) //MDP
        {

        }
    }
}
