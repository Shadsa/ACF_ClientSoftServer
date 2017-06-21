using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Office.Tools.Ribbon;

namespace OutlookAddInACF
{
    public partial class ThisAddIn
    {

        //APICall API; => A mettre dans chaque methode , ou alors a passer en param.

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Get the Application object
            Outlook.Application application = this.Application;

            // Get the Inspector object
            Outlook.Inspectors inspectors = application.Inspectors;

            // Get the active Inspector object
            Outlook.Inspector activeInspector = application.ActiveInspector();
            if (activeInspector != null)
            {
                // Get the title of the active item when the Outlook start.
                MessageBox.Show("Active inspector: " + activeInspector.Caption);
            }

            // Get the Explorer objects
            Outlook.Explorers explorers = application.Explorers;

            // Get the active Explorer object
            Outlook.Explorer activeExplorer = application.ActiveExplorer();
            if (activeExplorer != null)
            {
                // Get the title of the active folder when the Outlook start.
                MessageBox.Show("Active explorer: " + activeExplorer.Caption);
                
            }


            // ...
            // Add a new Inspector to the application
            inspectors.NewInspector +=
                new Outlook.InspectorsEvents_NewInspectorEventHandler(
                    Inspectors_AddTextToNewMail);

            application.ItemSend +=
        new Outlook.ApplicationEvents_11_ItemSendEventHandler(ItemSend_BeforeSend);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Remarque : Outlook ne déclenche plus cet événement. Si du code
            //    doit s'exécuter à la fermeture d'Outlook (consultez https://go.microsoft.com/fwlink/?LinkId=506785)
        }

        #region Events
        void Inspectors_AddTextToNewMail(Outlook.Inspector inspector)
        {
            // Get the current item for this Inspecto object and check if is type
            // of MailItem
            Outlook.MailItem mailItem = inspector.CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                if (mailItem.EntryID == null)
                {
                    mailItem.Subject = "My subject text";
                    mailItem.Body = "My body text";
                }
            }
        }
        void ItemSend_BeforeSend(object item, ref bool cancel)
        {
            Outlook.MailItem mailItem = (Outlook.MailItem)item;
           
            if (mailItem != null)
            {
                mailItem.Body += "Modified by GettingStartedOutlookAddIn";
            }
            cancel = false;
        }
        #endregion

        #region Code généré par VSTO

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion

    }
}
