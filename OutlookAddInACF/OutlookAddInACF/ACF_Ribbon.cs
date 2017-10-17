using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Xml.Serialization;

namespace OutlookAddInACF
{



    public partial class ACF_Ribbon
    {
        CookieUser actualCookie = null;
        string cookieName = "SessionInfo.xml";
        string folderName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        private void ACF_Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            checkAuthentification();
        }

        public bool checkAuthentification()
        {
            CookieUser cookie = new CookieUser();
            XmlSerializer serializer = new XmlSerializer(typeof(CookieUser));
            string pathStringFolder = Path.Combine(folderName, "ACF");
            string pathStringFile = System.IO.Path.Combine(pathStringFolder, cookieName);
            //Try if the directory of the AppData is already create or not 
            if (!System.IO.Directory.Exists(pathStringFolder))
            {
                System.Console.WriteLine("Le Dossier ACF dans AppData n'existe pas");
                SauvegarderMail.Enabled = false;
                SauvegarderPJ.Enabled = false;
                ParametreEnvoisMailAuto.Enabled = false;
                ExportFile.Enabled = false;
                AddContact.Enabled = false;
                AddReminder.Enabled = false;
                return false;
            }
            //Try if the cookie exist or not
            if (!System.IO.File.Exists(pathStringFile))
            {
               
                MessageBox.Show("ACF_Ribbon : pas de cookie, pas de panels !");
                SauvegarderMail.Enabled = false;
                SauvegarderPJ.Enabled = false;
                ParametreEnvoisMailAuto.Enabled = false;
                ExportFile.Enabled = false;
                AddContact.Enabled = false;
                AddReminder.Enabled = false;
                return false;
            }

            //Get the cookie authentification

            // Read the file and display it line by line.  
            FileStream myFileStream = new FileStream(pathStringFile, FileMode.Open);
            cookie = (CookieUser)serializer.Deserialize(myFileStream);
            if (cookie.IsAuthorized)
            {
                MessageBox.Show("ACF_Ribbon : OK authentif, j'active les panels");
                SauvegarderMail.Enabled = true;
                SauvegarderPJ.Enabled = true;
                ParametreEnvoisMailAuto.Enabled = true;
                ExportFile.Enabled = true;
                AddContact.Enabled = true;
                AddReminder.Enabled = true;
                actualCookie = cookie;
                myFileStream.Close();
                return true;
            }
            else
            {
                MessageBox.Show("ACF_Ribbon : pas authentifié, panells inactif");
                SauvegarderMail.Enabled = false;
                SauvegarderPJ.Enabled = false;
                ParametreEnvoisMailAuto.Enabled = false;
                ExportFile.Enabled = false;
                AddContact.Enabled = false;
                AddReminder.Enabled = false;
                myFileStream.Close();
                return false;

            }
            
        }

        private void SauvegarderMail_Click(object sender, RibbonControlEventArgs e)
        {
            // Get the Application object
            Outlook.Application application = Globals.ThisAddIn.Application;
            Outlook.Explorer activeExplorer = application.ActiveExplorer();
            Outlook.MAPIFolder selectedFolder = application.ActiveExplorer().CurrentFolder;


            String expMessage = "Your current folder is " + selectedFolder.Name + ".\n";
            String itemMessage = "Item is unknown.";

            try
            {
                if (application.ActiveExplorer().Selection.Count > 0)
                {
                    Object selObject = application.ActiveExplorer().Selection[1];

                    if (selObject is Outlook.MailItem)
                    {
                        Outlook.MailItem mailItem =
                            (selObject as Outlook.MailItem);
                        itemMessage = "The item is an e-mail message." +
                            " The subject is " + mailItem.Subject + ".";
                        APICallLibrary.SendMailToServerJSON(mailItem);
                        //mailItem.Display(false);
                    }
                    else if (selObject is Outlook.ContactItem)
                    {
                        Outlook.ContactItem contactItem =
                            (selObject as Outlook.ContactItem);
                        itemMessage = "The item is a contact." +
                            " The full name is " + contactItem.Subject + ".";
                        //contactItem.Display(false);
                    }

                    /* USE IT WHEN REMINDER ACCEPT THOSE DATA FORM
                    else if (selObject is Outlook.AppointmentItem)
                    {
                        Outlook.AppointmentItem apptItem =
                            (selObject as Outlook.AppointmentItem);
                        itemMessage = "The item is an appointment." +
                            " The subject is " + apptItem.Subject + ".";
                    }
                    else if (selObject is Outlook.TaskItem)
                    {
                        Outlook.TaskItem taskItem =
                            (selObject as Outlook.TaskItem);
                        itemMessage = "The item is a task. The body is "
                            + taskItem.Body + ".";
                    }
                    else if (selObject is Outlook.MeetingItem)
                    {
                        Outlook.MeetingItem meetingItem =
                            (selObject as Outlook.MeetingItem);
                        itemMessage = "The item is a meeting item. " +
                             "The subject is " + meetingItem.Subject + ".";
                    }*/


                }
                expMessage = expMessage + itemMessage;
            }
            catch (Exception ex)
            {
                expMessage = ex.Message;
            }
            MessageBox.Show(expMessage);

        }
        private void SauvegarderPJ_Click(object sender, RibbonControlEventArgs e)
        {

        }
        private void ParametreEnvoisMailAuto_Click(object sender, RibbonControlEventArgs e)
        {

        }
        private void ExportFile_Click(object sender, RibbonControlEventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                /*
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }*/
            }
        }
        private void AddReminder_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Application application = Globals.ThisAddIn.Application;
            Outlook.Explorer activeExplorer = application.ActiveExplorer();
            Outlook.MAPIFolder selectedFolder = application.ActiveExplorer().CurrentFolder;

            reminderForm form = new reminderForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                String username = activeExplorer.Session.CurrentProfileName;
                System.Collections.ArrayList data = form.retrieveData();
                form.Close();
                APICallLibrary.SendReminderToServerJSON(data, actualCookie.Mail);
            }
            else
            {
                form.Close();
            }

        }
        private void AddContact_Click(object sender, RibbonControlEventArgs e)
        {
            contactForm form = new contactForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                System.Collections.ArrayList data = form.retrieveData();
                form.Close();
                APICallLibrary.SendContactToServerJSON(data);
            }
            else
            {
                form.Close();
            }

        }





    }
}
