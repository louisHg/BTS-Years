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

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        ArrayList it = new ArrayList();
        private BDD bdd;
        public Form1()
        {
            InitializeComponent();
            bdd = new BDD();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            it = bdd.Lire();
            for (int i = 0; i < it.Count; i++)
            {
                ArrayList t = new ArrayList();
                t = (ArrayList)it[i];
                this.listBox1.Items.Add(t[0] + "\t" + t[1]);
            }
        }

        


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tes2 = listBox1.Text;
            ArrayList List = (ArrayList)it[listBox1.SelectedIndex];
            textBox2.Text = Convert.ToString(List[0]);
            textBox1.Text = Convert.ToString(List[1]);
            textBox3.Text = Convert.ToString(List[2]);
            textBox4.Text = Convert.ToString(List[3]);
            textBox5.Text = Convert.ToString(List[4]);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string tet = textBox2.Text;
            string tme = textBox1.Text;
            string tmme = textBox3.Text;
            string tmmm = textBox4.Text;
            bdd.Add_N(tme, tet, tmme, tmmm);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ArrayList List = (ArrayList)it[listBox1.SelectedIndex];
            string mdp = textBox4.Text;
            string dp = textBox5.Text;
            bdd.update(mdp, dp);
        }
    }
}

