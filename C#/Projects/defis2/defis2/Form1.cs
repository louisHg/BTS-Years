using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace defis2
{
    public partial class Form1 : Form
    {
        private BDD bdd;
        public Form1()
        {
            InitializeComponent();
            bdd = new BDD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  DateTime time = new DateTime();
            //time = DateTime.Now;
            string email,password;
            email = textBox1.Text;
            password = textBox2.Text;
            bdd.Add_BC(email,password);
        }
    }
}