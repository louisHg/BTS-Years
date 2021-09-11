using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testContainer
{
    public partial class IHM3D : Form
    {
        public IHM3D()
        {
            InitializeComponent();
            Button monBouton = new Button();
            monBouton.Text = "bonjour";
            monBouton.Width = 100;
            monBouton.Height = 100;
            monBouton.Left = 10;
            monBouton.Top = 10;
            monBouton.BackColor = Color.Pink;
            monBouton.Click += new EventHandler(button_Click);
            this.Controls.Add(monBouton);

            int nbrButton = 5;
            Button[] btn = new Button[nbrButton];
            for (int i = 0; i < nbrButton; i++) 
            {
                btn[i] = new Button();
                btn[i].Text = "BIC :" + (i + 1).ToString();
                btn[i].Height = 50;
                btn[i].Width = 100;
                btn[i].Click += new EventHandler(button_Click);
                btn[i].Left = i * 110;
                btn[i].Top = 50;
                this.Controls.Add(btn[i]);
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            bouton.Text = "Container \n" + bouton.Text;
            bouton.BackColor = Color.Red;
        }
    }
}
