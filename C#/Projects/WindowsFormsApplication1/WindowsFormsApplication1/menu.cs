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

namespace WindowsFormsApplication1
{
    public partial class menu : Form
    {
        ArrayList lesTextDeMenu = new ArrayList();
        private BDD bdd;
        public menu(ArrayList lesText)
        {
            bdd = new BDD();
            int count = bdd.nombreContainer();
            this.lesTextDeMenu = lesText;
            InitializeComponent();
            label1.Text = (string)lesTextDeMenu[1];
            label3.Text = count.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ajouter Ajouter = new Ajouter();
            Ajouter.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste Liste = new Liste();
            Liste.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IHM3D IHM3D = new IHM3D();
            IHM3D.Show();
            this.Hide();
        }
    }
}
