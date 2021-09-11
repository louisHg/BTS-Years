using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projet_container
{
    public partial class menu : Form
    {
        private BDD bdd;
        public menu()
        {
            bdd = new BDD();
            int count = bdd.nbContainer();
            string i = count.ToString();
            InitializeComponent();
            label5.Text = i;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;

            for (int j=0; j < count; j++)
            {
                this.progressBar1.Increment(1);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Liste Liste = new Liste();
            Liste.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ajouter Ajouter = new Ajouter();
            Ajouter.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IHM3D IHM3D = new IHM3D();
            IHM3D.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connexion connexion = new connexion();
            connexion.Show();
            this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
