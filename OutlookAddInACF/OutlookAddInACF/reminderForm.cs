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
    public partial class reminderForm : Form
    {

        private System.Collections.ArrayList data = new System.Collections.ArrayList();
        public reminderForm()
        {
            InitializeComponent();
        }

        public System.Collections.ArrayList retrieveData()
        {
            data.Add(data_ReminderObject.Text);           
            data.Add(data_DateReminder.Value);
            data.Add(data_NoteReminder.Text);
            return data;
        }



        #region Truc qu'on peut pas elever

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
#endregion 
    }
}
