using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebFormz
{
    static class WebFormReader
    {

        public static List<WebFormItem> GetWebFormz(string xml)
        {
            List<WebFormItem> items = new List<WebFormItem>();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNodeList elemList = doc.GetElementsByTagName("item");

            for(int i = 0; i < elemList.Count; i++)
            {
                items.Add(new WebFormItem()
                {
                    WebFormZNo = elemList[i].Attributes["webformzno"].Value,
                    WebFormZKey = elemList[i].Attributes["webformzkey"].Value,
                    ConfirmationPage = elemList[i].Attributes["filepath"].Value,
                    CustomJavascript = (CustomJavascript)int.Parse(elemList[i].Attributes["customjavascript"].Value)
                });
            }
            
            return items;
        }
    }
}
