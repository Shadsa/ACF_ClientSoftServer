using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace OutlookAddInACF
{
    class APICallLibrary
    {
        #region Setup API
            //Everything is send in JSON
            private static readonly HttpClient client = new HttpClient();
            private static String ServerURL = "http://localhost:8080";
            private static String APIRoad = "/api/";
            private static String MailRoad = "mail";
            private static String ContactRoad = "contact";
            private static String ReminderRoad = "reminder";
            private static String DataRoad = "data";
            private static String AuthRoad = "authentification";
        //private String APIKey = "1zeyw3z4623ywehfgaeik235f5f48ga64u1qfae9/"; =>Security Option
        #endregion

        #region Authentification API

        public static JObject CheckForAuthentification(String mail, String mdp)
        {
            JObject Auth = new JObject();
            Auth["Mail"] = mail;
            Auth["Password"] = mdp;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ServerURL + APIRoad + AuthRoad);
            JObject answer = GenericSender(httpWebRequest, Auth);

            return answer;

        }




        #endregion

        #region Code API
        //Envois de donnée au serveur applicatif avec méthode POST au format JSON


        public static void SendAttachPieceToServer(Outlook.MailItem mail)
        {

        }
        public static void SendFileToServer(object item)
        {

        }
        public static void SendMailToServerJSON(Outlook.MailItem mail)
        {
            JObject o = MailParserToJson(mail);
            String JItem = JsonConvert.SerializeObject(o);
            MessageBox.Show(JItem);
            SendMailJsonWithPost(o);
        }
        public static void SendReminderToServerJSON(System.Collections.ArrayList item, String Mail)
        {
            JObject o = ReminderParserToJson(item,Mail);
            String JItem = JsonConvert.SerializeObject(o);
            MessageBox.Show(JItem);
            SendReminderJsonWithPost(o);
        }
        public static void SendContactToServerJSON(System.Collections.ArrayList item)
        {
            JObject o = ContactParserToJson(item);
            String JItem = JsonConvert.SerializeObject(o);
            MessageBox.Show(JItem);
            SendContactJsonWithPost(o);
        }
        public static void SendContactToServerJSON(Outlook.ContactItem item)
        {
            JObject o = ContactParserToJson(item);
            String JItem = JsonConvert.SerializeObject(o);
            MessageBox.Show(JItem);
            SendContactJsonWithPost(o);
        }
        public static void SendEntrepriseToServerJSON(object item)
        {

        }
        #endregion

        #region HttpSenders

        private static void SendMailJsonWithPost(JObject o)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ServerURL+APIRoad+MailRoad);
            GenericSender(httpWebRequest, o);

        }
        private static void SendReminderJsonWithPost(JObject o)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ServerURL + APIRoad + ReminderRoad);
            GenericSender(httpWebRequest, o);

        }
        private static void SendContactJsonWithPost(JObject o)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ServerURL + APIRoad + ContactRoad);
            GenericSender(httpWebRequest, o);

        }
        private static JObject GenericSender(System.Net.HttpWebRequest adress, JObject o )
        {
            var httpWebRequest = adress;
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(o);

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
                return JObject.Parse(result);
            }
        }


        #endregion 

        #region Parser/Tools
        private static JObject MailParserToJson(Outlook.MailItem mail)
        {
            JObject o = new JObject();

            o["SenderMail"] = mail.SenderEmailAddress;
            o["SenderNom"] = mail.SenderName;
            o["Objet"] = mail.Subject;
            o["Body"] = mail.HTMLBody;
            o["CC"] = mail.CC;
            o["BCC"] = mail.BCC;
            o["Date"] = mail.ReceivedTime.ToString();
            return o;
        }
        private static JObject ContactParserToJson(System.Collections.ArrayList contact)
        {
            JObject o = new JObject();
            o["Entreprise"]= (String) contact[0];
            o["Adresse"] = (String)contact[1];
            o["CP"]= (String)contact[2];
            o["Ville"]= (String)contact[3];
            o["Civilite"]= (String)contact[5];
            o["Nom"]= (String)contact[5];
            o["Telephone"]= (String)contact[7];
            o["Fonction"]= (String)contact[6];
            o["Email"]= (String)contact[8];
            o["Client"] = (Boolean) contact[9];


            return o;
        }
        private static JObject ContactParserToJson(Outlook.ContactItem contact)
        {
            JObject o = new JObject();

            o["Entreprise"] = contact.CompanyName;
            o["Adresse"] = contact.BusinessAddress;
            o["CP"] = contact.BusinessAddressPostalCode;
            o["Ville"] = contact.BusinessAddressCity;
            o["Civilite"] = contact.Gender.ToString();
            o["Nom"] = contact.LastName;
            o["Telephone"] = contact.BusinessTelephoneNumber;
            o["Fonction"] = contact.Department;
            o["Email"] = contact.Email1Address;
            o["Client"] = true;


            return o;
        }
        private static JObject ReminderParserToJson(System.Collections.ArrayList reminder, String Mail)
        {
            JObject o = new JObject();

            o["Objet"] = (String)reminder[0];
            o["Date"] = (String) reminder[1].ToString();
            o["Note"] = (String) reminder[2];
            o["Valider"] = false;
            o["Owner"] = Mail;


            return o;
        }


        #endregion
    }


}
