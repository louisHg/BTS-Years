using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testContainer
{
    public partial class Defis : Form
    {
        BDD bdd;
        ArrayList personnes = new ArrayList();
        ArrayList messages = new ArrayList();


        public Defis()
        {
            bdd = new BDD();
            InitializeComponent();
            lirePersonne();
            lireMessage();
    //        DateTime Date = DateTime.Parse("2020-04-03 14:35:43");
        }
        private void lirePersonne(){
            this.listBoxPersonnes.Items.Clear();
            personnes = bdd.getPersonnes();
            for (int i = 0; i < personnes.Count; i++)
            {
                ArrayList t = new ArrayList();
                t = (ArrayList)personnes[i];
                this.listBoxPersonnes.Items.Add(t[1] + "\t" + t[2]);
            }
        }
        private void lireMessage()
        {
            this.listBoxMessages.Items.Clear();
            messages = bdd.getMessages();
            for (int i = 0; i < messages.Count; i++)
            {
                ArrayList t = new ArrayList();
                t = (ArrayList)messages[i];
                this.listBoxMessages.Items.Add(t[3] + "\t" + t[2] + "\tde " + t[0] + "\t pour " + t[1]);
            }
        } 
        private void listBoxPersonnes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList laPersonne = (ArrayList)personnes[listBoxPersonnes.SelectedIndex];
            int id = int.Parse(laPersonne[0].ToString());
            this.textBoxId.Text = laPersonne[0].ToString();
            this.textBoxNom.Text = (string)laPersonne[1];
            this.textBoxPrenom.Text = (string)laPersonne[2];
            this.textBoxLogin.Text = (string)laPersonne[3];
            this.textBoxPassword.Text = (string)laPersonne[4];

            this.listBoxMessages.Items.Clear();
            messages = bdd.getMesMessages(id);
            for (int i = 0; i < messages.Count; i++)
            {
                ArrayList t = new ArrayList();
                t = (ArrayList)messages[i];
                this.listBoxMessages.Items.Add(t[3] + "\t" + t[2] + "\tde " + t[0] + "\t pour " + t[1]);
            }


        }
        private void buttonCreer_Click(object sender, EventArgs e)
        {
            string nom = this.textBoxNom.Text;
            string prenom = this.textBoxPrenom.Text;
            string login = this.textBoxLogin.Text;
            string password = this.textBoxPassword.Text;
            bdd.setPersonne(nom, prenom, login, password);
            lirePersonne();
        }
        private void buttonMDP_Click(object sender, EventArgs e)
        {           
            string mdp = this.textBoxPassword.Text;
            string login = this.textBoxLogin.Text;
            bdd.changerMdp(login, mdp);
            lirePersonne();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime laDate = DateTime.Parse(this.textBoxDate.Text);
            string login=bdd.chercherIntrus(laDate);
            this.textBoxIntrus.Text = login;
        }

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
