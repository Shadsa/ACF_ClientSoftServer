using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookAddInACF
{
    public partial class contactForm : Form
    {
        private System.Collections.ArrayList data = new System.Collections.ArrayList();
        public contactForm()
        {
            InitializeComponent();
        }

        public System.Collections.ArrayList retrieveData()
        {
           
            data.Add(data_Entreprise_Box.Text);
            data.Add(data_Adresse_Box.Text);
            data.Add(data_CP_Box.Text);
            data.Add(data_Ville_Box.Text);
            data.Add(data_Nom_Box.Text);
            data.Add(data_Civilite_Box.Text);
            data.Add(data_Fonction_Box.Text);
            data.Add(data_Tel_Box.Text);
            data.Add(data_Mail_Box.Text);
            data.Add(data_clientvalue.Text);
            return data;
        }

        #region Truc qu'on peut pas enlever 

        private void contactForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ContactName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        #endregion 
    }
}
