using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OutlookAddInACF
{
    public partial class AuthControl : UserControl
    {
        
        string cookieName = "SessionInfo.xml";
        string folderName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public AuthControl()
        {
            InitializeComponent();
            

        }

        private void OnClick(object sender, System.EventArgs e)
        {
            CookieUser cookie = new CookieUser();
            XmlSerializer serializer = new XmlSerializer(typeof(CookieUser));
            string pathStringFolder = Path.Combine(folderName, "ACF");
            string pathStringFile = System.IO.Path.Combine(pathStringFolder, cookieName);

            JObject response = APICallLibrary.CheckForAuthentification(data_Mail.Text,data_password.Text);
            if((bool) response["Auth"] == true)
            {
                MessageBox.Show("AuthControl : OK authentif, je modifie le cookie");
                cookie.IsAuthorized = true;
                cookie.Name = (String)response["User"];
                cookie.Mail = data_Mail.Text;
                System.IO.File.Delete(pathStringFile); //dans le doute, j'ecris un nouveau cookie
                TextWriter writer = new StreamWriter(pathStringFile);                
                serializer.Serialize(writer, cookie);
                writer.Close();
                this.SetVisibleCore(false);
                this.Visible = false;
            }
            else
            {
                MessageBox.Show(response + " : => AuthControl : Authentification refusé, recommencez !");
            }


            
        }
    }
}
