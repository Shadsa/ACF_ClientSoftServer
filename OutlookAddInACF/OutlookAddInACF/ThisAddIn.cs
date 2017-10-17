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
using Newtonsoft.Json.Linq;
using Microsoft.Office.Tools.Ribbon;
using System.IO;
using System.Xml.Serialization;

namespace OutlookAddInACF
{
    public partial class ThisAddIn
    {
        //Cookie doc : { (0)Authentification : 0 or 1, (1)Username: String, (2)Mail:String}
        string cookieName = "SessionInfo.xml";
        string folderName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private AuthControl myUserControl1 = new AuthControl();
        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            CookieUser cookie = new CookieUser();
            XmlSerializer serializer = new XmlSerializer(typeof(CookieUser));
            string pathStringFolder = Path.Combine(folderName, "ACF");
            string pathStringFile = System.IO.Path.Combine(pathStringFolder, cookieName);
            Outlook.Application application = Globals.ThisAddIn.Application;
            Outlook.Explorer activeExplorer = application.ActiveExplorer();
            Outlook.MAPIFolder selectedFolder = application.ActiveExplorer().CurrentFolder;
            Outlook.Explorers explorers = application.Explorers;
            Outlook.Inspectors inspectors = application.Inspectors;
            Outlook.Inspector activeInspector = application.ActiveInspector();

            //Try if the directory of the AppData is already create or not 
            if (! System.IO.Directory.Exists(pathStringFolder))
            {
                System.IO.Directory.CreateDirectory(pathStringFolder);
                TextWriter writer = new StreamWriter(pathStringFile);
                serializer.Serialize(writer, cookie);
                writer.Close();
            }

            //Try if the cookie exist or not
            if (! System.IO.File.Exists(pathStringFile))
            {
                TextWriter writer = new StreamWriter(pathStringFile);
                serializer.Serialize(writer, cookie);
                writer.Close();
            }

            //Get the cookie authentification
            
            // Read the file and display it line by line.  
            FileStream myFileStream = new FileStream(pathStringFile, FileMode.Open);
            cookie = (CookieUser)serializer.Deserialize(myFileStream);

            if (cookie.IsAuthorized)
            {
                System.Console.WriteLine("C'est OK !");
            }
            else
            {
                //Open the connection interface
                myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl1, "ACF : Authentification");
                myCustomTaskPane.Visible = true;            
                myCustomTaskPane.VisibleChanged += new EventHandler(myCustomTaskPane_VisibleChanged);

            }
            myFileStream.Close();
            
            // Get the active Inspector object
           
            if (activeInspector != null)
            {
                // Get the title of the active item when the Outlook start.
                MessageBox.Show("Active inspector: " + activeInspector.Caption);
            }

         
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
        private void myCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            bool answer = Globals.Ribbons.ACF_Ribbon.checkAuthentification();
        }

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
