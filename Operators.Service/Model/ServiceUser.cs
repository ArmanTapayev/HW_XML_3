using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Operators.Service.Model
{
    public class ServiceUser
    {
        private string path { get; set; }
        public ServiceUser(string Path)
        {
            path = Path;
        }
        private XmlDocument GetDocument()
        {
            FileInfo f = new FileInfo(path);
            XmlDocument doc = new XmlDocument();
            XmlDeclaration prolog =
              doc.CreateXmlDeclaration("1.0", "UTF-8", "");
            doc.AppendChild(prolog);
            if (f.Exists)
            {
                doc.Load(path);
                if (doc.DocumentElement == null)
                {
                    XmlElement el = doc.CreateElement("Users");
                    doc.AppendChild(el);
                    doc.Save(path);
                }
            }
            else
            {
                XmlElement el = doc.CreateElement("Users");
                doc.AppendChild(el);
                doc.Save(path);
            }
            return doc;
        }

        /// <summary>
        /// метод регистрации
        /// </summary>
        /// <param name="user">info user</param>
        /// <returns></returns>
        public bool Registration(User user)
        {
            XmlDocument doc = GetDocument();

            XmlElement User = doc.CreateElement("User");

            XmlElement Login = doc.CreateElement("Login");
            Login.InnerText = user.Login;
            User.AppendChild(Login);

            XmlElement Password = doc.CreateElement("Password");
            Password.InnerText = user.Password;
            User.AppendChild(Password);

            XmlElement Fullname = doc.CreateElement("Fullname");
            Fullname.InnerText = user.FullName;
            User.AppendChild(Fullname);

            doc.DocumentElement.AppendChild(User);
            try
            {
                doc.Save(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User LogOn (string login, string password)
        {
            XmlDocument check = GetDocument();
            foreach (XmlNode item in
                check.SelectNodes("Users/User"))
            {
                if(item.SelectSingleNode("Login").InnerText == login 
                    && item.SelectSingleNode("Password").InnerText == 
                    password)
                {
                    User ruser = new User();
                    ruser.FullName = 
                        item.SelectSingleNode("Fullname").InnerText;
                    ruser.Login = login;
                    ruser.Password = password;
                    return ruser;
                }
            }

            return null;
        }
        

    }
}
