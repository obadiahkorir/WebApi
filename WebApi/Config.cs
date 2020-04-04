using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using WebApi.OData;

namespace WebApi
{
    public class Config
    {
        public static NAV ReturnNav()
        {

            NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]))
            {
                Credentials =
                    new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                        ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"])
            };
            return nav;
        }
        public CuePortal.CuePortal ObjNav()
        {
            var ws = new CuePortal.CuePortal();
            try
            {
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                    ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
                ws.Credentials = credentials;
                ws.PreAuthenticate = true;


            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return ws;
        }
        public static String Receiver()
        {
            return ConfigurationManager.AppSettings["Receiver"];
        }
        public Boolean IsAllowedExtension(String extension)
        {
            Boolean check = Convert.ToBoolean(ConfigurationManager.AppSettings["CheckFileExtensions"]);
            if (check)
            {
                String allowedFileTypes = ConfigurationManager.AppSettings["AllowedFileExtensions"];
                String[] info = allowedFileTypes.Split(',');
                extension = extension.Replace('.', ' ');
                extension = extension.Trim();
                extension = extension.ToLower();
                foreach (String fileExtension in info)
                {
                    String myExtension = fileExtension;
                    myExtension = myExtension.Replace('.', ' ');
                    myExtension = myExtension.Trim();
                    myExtension = myExtension.ToLower();
                    if (myExtension == extension)
                    {
                        return true;
                    }
                }

            }
            else
            {
                return true;
            }
            return false;
        }

    }

}
