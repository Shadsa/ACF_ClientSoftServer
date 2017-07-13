using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace OutlookAddInACF
{
    public partial class ACF_Ribbon
    {
        private void ACF_Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

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

    }
}
