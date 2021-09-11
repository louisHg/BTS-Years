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

namespace defis_cine
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
            string marque,marque_temps,cine,cine_film;
            marque = textBox1.Text;
            marque_temps = textBox2.Text;
            cine = textBox3.Text;
            cine_film = textBox4.Text;
            string cine_freq = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);      
            int marque_note, cine_note;

            marque_note = int.Parse(this.comboBox3.Text);
            cine_note = int.Parse(this.comboBox4.Text);

            if (cine_note < 0 || cine_note > 10 || marque_note < 0 || marque_note > 10)
            {
                label10.Text = "ERREUR Veuillez vérifier vos réponse";
            }
            else 
            {
                bdd.Add_C(marque, marque_temps, cine, cine_film, marque_note, cine_freq, cine_note);
                label10.Text = "Merci pour vos réponse";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label10.Text = ""; 
            label11.Text = "";
            label12.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int marquenote = bdd.Lire_marquenote(comboBox1.SelectedItem.ToString());
            MessageBox.Show("la note de cette marque est: " + marquenote);
            decimal val = bdd.Lire_M();
            MessageBox.Show("La moyenne est de tout les résultats est : " + val);
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ArrayList List = new ArrayList();
            List = bdd.Lire_marque();
            this.comboBox1.Items.Clear();
            for (int i = 0; i < List.Count; i++)
                this.comboBox1.Items.Add(List[i]);
        }

        private void comboBox5_MouseClick(object sender, MouseEventArgs e)
        {
            ArrayList List = new ArrayList();
            List = bdd.Lire_cine();
            this.comboBox5.Items.Clear();
            for (int i = 0; i < List.Count; i++)
                this.comboBox5.Items.Add(List[i]);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cinenote = bdd.Lire_cinenote(comboBox5.SelectedItem.ToString());
            MessageBox.Show("la note de cette marque est: " + cinenote);
            decimal val = bdd.Lire_C();
            MessageBox.Show("La moyenne est de tout les résultats est : " + val);
        }
    }
}
