using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;


namespace Operators.Service.Model
{
    public class Service
    {
        private string path { get; set; }
        public Service(string Path)
        {
            path = Path;
        }
        private XmlDocument GetDocument ()
        {
            FileInfo f = new FileInfo(path);
            XmlDocument doc = new XmlDocument();
            XmlDeclaration prolog =
              doc.CreateXmlDeclaration("1.0", "UTF-8", "");
            doc.AppendChild(prolog);
            if (f.Exists)
            {
                doc.Load(path);
                if(doc.DocumentElement==null)
                { 
                    XmlElement el = doc.CreateElement("operators");
                    doc.AppendChild(el);
                    doc.Save(path);
                }
            }
            else
            {
                XmlElement el = doc.CreateElement("operators");
                doc.AppendChild(el);
                doc.Save(path);
            }
            return doc;
        }

        public bool CreateOperator (Operator op)
        {
            if (CheckOperator(op.Name))
            {
                XmlDocument doc = GetDocument();

                XmlElement MobOper = doc.CreateElement("Operator");

                XmlElement oper = doc.CreateElement("Name");
                oper.InnerText = op.Name;
                MobOper.AppendChild(oper);

                XmlElement logo = doc.CreateElement("Logo");
                logo.InnerText = op.Logo;
                MobOper.AppendChild(logo);

                XmlElement Percent = doc.CreateElement("Percent");
                Percent.InnerText = op.Percent.ToString();
                MobOper.AppendChild(Percent);

                XmlElement Prefixes = doc.CreateElement("Prefixes");

                foreach (int opi in op.Prefixes)
                {
                    if (CheckPrefix(opi))
                    {
                        XmlElement Prefix = doc.CreateElement("Prefix");
                        Prefix.InnerText = opi.ToString();
                        //<Prefix>777</Prefix>
                        Prefixes.AppendChild(Prefix);
                    }
                    else
                    {
                        //Nothing
                    }
                }
                MobOper.AppendChild(Prefixes);

                doc.DocumentElement.AppendChild(MobOper);

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
            else return false;
          
        }

        private bool CheckOperator(string name)
        {

            XmlDocument check = GetDocument();
            foreach (XmlNode MobName in 
                check.SelectNodes("operators/Operator/Name"))
            {
                if(MobName.InnerText==name)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckPrefix(int pref)
        {

            XmlDocument check = GetDocument();
            foreach (XmlNode MobName in
                check.SelectNodes("operators/Operator/Prefixes/Prefix"))
            {
                if (MobName.InnerText == pref.ToString())
                {
                    return false;
                }
            }
            return true;
        }

    }
}
