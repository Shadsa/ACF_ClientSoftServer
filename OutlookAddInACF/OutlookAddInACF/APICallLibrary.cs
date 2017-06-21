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

namespace OutlookAddInACF
{
    class APICallLibrary
    {
        private static readonly HttpClient client = new HttpClient();
        private static String ServerURL = "http://localhost:8080";
        private static String APIRoad = "/api/";
        //private String APIKey = "1zeyw3z4623ywehfgaeik235f5f48ga64u1qfae9/"; =>Security Option

        #region Code API
        //Envois de donnée Mail au serveur applicatif avec méthode POST au format JSON
        public static void SendMailToServerJSON(Outlook.MailItem mail)
        {
            String JItem = JsonConvert.SerializeObject(MailParserToJson(mail));
            MessageBox.Show(JItem);
        }

        public static void SendAttachPieceToServer(Outlook.MailItem mail)
        {

        }

        public static void SendFileToServer(object item)
        {

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
            return o;
        }
        #endregion
    }


}
