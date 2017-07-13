﻿using System;
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
        //Everything is send in JSON
        private static readonly HttpClient client = new HttpClient();
        private static String ServerURL = "http://localhost:8080";
        private static String APIRoad = "/api/";
        private static String MailRoad = "mail";
        private static String ContactRoad = "contact";
        private static String ReminderRoad = "reminder";
        private static String EntrepriseRoad = "entreprise";
        //private String APIKey = "1zeyw3z4623ywehfgaeik235f5f48ga64u1qfae9/"; =>Security Option

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
        public static void SendReminderToServerJSON(object item)
        {

        }
        public static void SendContactToServerJSON(object item)
        {

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
        private static void SendEntrepriseJsonWithPost(JObject o)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ServerURL + APIRoad + EntrepriseRoad);
            GenericSender(httpWebRequest, o);

        }
        private static void GenericSender(System.Net.HttpWebRequest adress, JObject o )
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
            }
        }


        #endregion 

        #region Parser/Tools
        private static JObject MailParserToJson(Outlook.MailItem mail)
        {
            JObject o = new JObject();

            JArray senderInformation = new JArray();
            senderInformation.Add(mail.SenderEmailAddress);
            senderInformation.Add(mail.SenderName);

            o["Sender"] = senderInformation;
            o["Subject"] = mail.Subject;
            o["Body"] = mail.HTMLBody;
            o["CC"] = mail.CC;
            o["BCC"] = mail.BCC;
            o["Date"] = mail.ReceivedTime.ToString();
            return o;
        }
        private static JObject ContactParserToJson(Outlook.ContactItem contact)
        {
            JObject o = new JObject();
            
            o["Entreprise"]= contact.CompanyName;
            o["Adresse"] = contact.BusinessAddress;
            o["CP"]=contact.BusinessAddressPostalCode;
            o["Ville"]=contact.BusinessAddressCity;
            o["Civilite"]=contact.Gender.ToString();
            o["Nom"]=contact.LastName;
            o["Telephone"]=contact.BusinessTelephoneNumber;
            o["Fonction"]=contact.Department;
            o["Email"]=contact.Email1Address;
            o["Client"] = true;

            
            return o;
        }
        private static JObject ReminderParserToJson(Outlook.MailItem mail)
        {
            JObject o = new JObject();

            JArray senderInformation = new JArray();
            senderInformation.Add(mail.SenderEmailAddress);
            senderInformation.Add(mail.SenderName);

            o["Sender"] = senderInformation;
            o["Subject"] = mail.Subject;
            o["Body"] = mail.HTMLBody;
            o["CC"] = mail.CC;
            o["BCC"] = mail.BCC;
            o["Date"] = mail.ReceivedTime.ToString();
            return o;
        }


        #endregion
    }


}
