using Browser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace WebFormz
{
    class Program
    {
        static void Main(string[] args)
        {
            iMIS imis = new iMIS(iMISConfig.Domain);
            imis.Login();
            List<WebFormItem> items = WebFormReader.GetWebFormz();

            foreach(WebFormItem item in items)
            {
                imis.BuildWebForm(item);
                imis.InsertScript(item);
            }
        }
    }
}
