using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication5
{
    public partial class IHM3D : Form
    {



        private BDD bdd;
        private Button[, , ,] btn;
        int nbligne;
        int etage;
        int nbcolonne;
        int zonemax;



        public IHM3D()
        {
            InitializeComponent();
            bdd = new BDD();
            nbligne = 6;
            etage = 6;
            nbcolonne = 10;
            zonemax = 2;



            btn = new Button[zonemax, nbligne, nbcolonne, etage];



            for (int zone1 = 0; zone1 < zonemax; zone1++)
            {
                for (int x1 = 0; x1 < nbligne; x1++)
                {
                    for (int y1 = 0; y1 < nbcolonne; y1++)
                    {
                        for (int z1 = etage - 1; z1 >= 0; z1--)
                        {
                            btn[zone1, x1, y1, z1] = new Button();
                            btn[zone1, x1, y1, z1].Text = "Zone: " + (zone1).ToString() + "\nX:" + (x1).ToString() + "\nY:" + (y1).ToString() + "\nZ:" + (z1).ToString();
                            btn[zone1, x1, y1, z1].TextAlign = ContentAlignment.TopLeft;
                            btn[zone1, x1, y1, z1].Height = 65;
                            btn[zone1, x1, y1, z1].Click += new EventHandler(button_Click);
                            btn[zone1, x1, y1, z1].Left = x1 * 100;
                            btn[zone1, x1, y1, z1].Top = 5 * 50 - z1 * 60 + 130;
                            bool oqp = bdd.DetectContainer(zone1, x1, y1, z1);
                            if (!oqp)
                            {
                                int dimSus = bdd.SelectDimension(zone1, x1, y1, z1 + 1);
                                int dimSous = bdd.SelectDimension(zone1, x1, y1, z1 - 1);
                                if (dimSous >= 40 || (z1 - 1) < 0 && dimSus == 0)
                                {
                                    btn[zone1, x1, y1, z1].BackColor = Color.Green;
                                    btn[zone1, x1, y1, z1].Width = 100;
                                }
                                else
                                {
                                    btn[zone1, x1, y1, z1].BackColor = Color.Red;
                                    btn[zone1, x1, y1, z1].Width = 100;
                                }
                            }



                            else
                            {
                                btn[zone1, x1, y1, z1].BackColor = Color.Gray;
                                int dim = bdd.SelectDimension(zone1, x1, y1, z1);
                                if (dim == 20)
                                {
                                    btn[zone1, x1, y1, z1].Width = 70;
                                }
                                else
                                {
                                    btn[zone1, x1, y1, z1].Width = 100;
                                }
                            }
                            this.Controls.Add(btn[zone1, x1, y1, z1]);
                        }
                    }
                }
            }
        }



        private void button_Click(object sender, EventArgs e)
        {
            Button bouton = (Button)sender;
            Liste Liste = new Liste();
            Liste.Show();
            this.Hide();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            for (int zone1 = 0; zone1 < zonemax; zone1++)
            {
                for (int x1 = 0; x1 < nbligne; x1++)
                {
                    for (int y1 = 0; y1 < nbcolonne; y1++)
                    {
                        for (int z1 = etage - 1; z1 >= 0; z1--)
                        {
                            int zone2 = Convert.ToInt16(numericUpDown1.Value);
                            int y2 = Convert.ToInt16(numericUpDown2.Value);
                            btn[zone1, x1, y1, z1].Text = "Zone: " + (zone2).ToString() + "\nX:" + (x1).ToString() + "\nY:" + (y2).ToString() + "\nZ:" + (z1).ToString();
                            btn[zone1, x1, y1, z1].TextAlign = ContentAlignment.TopLeft;
                            bool oqp = bdd.DetectContainer(zone2, x1, y2, z1);
                            if (!oqp)
                            {
                                int dimSus = bdd.SelectDimension(zone2, x1, y2, z1 + 1);
                                int dimSous = bdd.SelectDimension(zone2, x1, y2, z1 - 1);
                                if (dimSous >= 40 || (z1 - 1) < 0 && dimSus == 0)
                                {
                                    btn[zone1, x1, y1, z1].BackColor = Color.Green;
                                    btn[zone1, x1, y1, z1].Width = 100;
                                }
                                else
                                {
                                    btn[zone1, x1, y1, z1].BackColor = Color.Red;
                                    btn[zone1, x1, y1, z1].Width = 100;
                                }
                            }
                            else
                            {
                                btn[zone1, x1, y1, z1].BackColor = Color.Gray;
                                int dim = bdd.SelectDimension(zone2, x1, y2, z1);
                                if (dim == 20)
                                {
                                    btn[zone1, x1, y1, z1].Width = 70;
                                }
                                else { btn[zone1, x1, y1, z1].Width = 100; }
                            }
                        }
                    }
                }
            }
        }
    }
}