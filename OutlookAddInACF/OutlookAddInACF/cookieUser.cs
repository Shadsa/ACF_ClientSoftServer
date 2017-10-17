using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OutlookAddInACF
{
    [XmlRootAttribute("CookieUser", Namespace = "OutlookAddInACF", IsNullable = false)]
    public class CookieUser
    {
        //Extensible, rediger pour une serialisation XML
        public bool IsAuthorized = false;
        public string Name = "";
        public string Mail = "";

        

    }
}
