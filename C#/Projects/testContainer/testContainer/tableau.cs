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
    public partial class tableau : Form
    {
        public tableau()
        {
            InitializeComponent();
            Button monBouton = new Button();
            monBouton.Text = "bonjour";
            monBouton.Width = 100;
            monBouton.Height = 100;
            monBouton.Left = 10;
            monBouton.Top = 300;
            monBouton.BackColor = Color.Pink;
            monBouton.Click += new EventHandler(button1_Click);
            this.Controls.Add(monBouton);
     
            int nbligne = 5;
            int nbcolonne = 4;
            Button[,] btn = new Button[nbligne, nbcolonne];

            for (int x = 0; x < nbligne; x++)
            {
                for(int y = 0; y < nbcolonne; y++)
                {
                    btn[x, y] = new Button();
                    btn[x, y].Text = "BIC: " + (x + 1).ToString()+(y+1).ToString();
                    btn[x, y].Height = 50;
                    btn[x, y].Width = 100;
                    btn[x, y].Click += new EventHandler(button1_Click);
                    btn[x, y].Left = y* 110;
                    btn[x, y].Top =50+ x* 50;
                    this.Controls.Add(btn[x, y]);
                }
            }
        }
    
    private void button1_Click(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            bouton.Text = "Container \n" + bouton.Text;
            bouton.BackColor = Color.Red;
        }
    }
}
