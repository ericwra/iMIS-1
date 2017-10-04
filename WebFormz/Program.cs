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
            bool loggedin = false;
            string username, password = "";

            do
            {
                Console.WriteLine("Please enter your iMIS credentials.\n");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                Console.Clear();
                loggedin = imis.Login(username, password);
                //Console.WriteLine(loggedin);
                Console.WriteLine("{0}", loggedin ? "Successfuly loged in" : "Failed to login");
                

            } while (!loggedin);

            /*
            foreach(WebFormItem item in items)
            {
               // imis.BuildWebForm(item);
               // imis.InsertScript(item);
            }
            */
        }
    }
}
