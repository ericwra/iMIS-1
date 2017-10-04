using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using WebFormz.Helpers;
using WebFormz.Interfaces;

namespace WebFormz
{
    class iMIS : IiMIS
    {
        private Browser browser;
        private string domain;

        private const int MAX_TRIES = 5;
        private const string LOGIN_ERROR = "Logon Failed.";
        private const string WEBFORM_ERROR = "This form is not upto date.";

        private static string SCRIPT_FORMAT = @"\\{0}\c$\Program Files (x86)\ASI\iMIS\Net{1}";
        private static string SCRIPT_PLACEMENT = "</script>";


        public iMIS(string domain)
        {
            this.domain = domain;
            this.browser = new Browser(120);
        }

        /// <summary>
        /// Logs into iMis using the supplied username and password. 
        /// </summary>
        /// <param name="username">String containing the username</param>
        /// <param name="password">String containing the password</param>
        /// <returns>Returns a boolean indicating wether </returns>
        public bool Login(string username,string password)
        {
            try
            {
                browser.GoToUrl(string.Format(iMISConfig.LoginURL, domain));
                browser.SendKeys(iMISConfig.UsernameTextBox, username);
                browser.SendKeys(iMISConfig.PasswordTextBox, password);
                browser.Click(iMISConfig.SignInButton);
                return !Parser.Match(browser.GetPageSource(), LOGIN_ERROR);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to login. Check logs for more information");
            }
            return false;
        }

        /// <summary>
        /// Builds a webform and will retry on failed builds.
        /// </summary>
        /// <param name="item">WebFormItem</param>
        public void BuildWebForm(WebFormItem item)
        {
            try
            {
                bool succeeded = false;
                int attempts = 0;
                do
                {
                    browser.GoToUrl(string.Format(iMISConfig.WebFormURL, domain, item.WebFormZKey));
                    browser.Click(iMISConfig.CmsTab);
                    if (!browser.IsChecked(iMISConfig.ConfirmationPageCheckBox))
                    {
                        browser.Click(iMISConfig.ConfirmationPageCheckBox);
                    }
                    browser.Click(iMISConfig.SaveButon);
                    browser.Click(iMISConfig.BuildButton);
                    succeeded = !Parser.Match(browser.GetPageSource(), WEBFORM_ERROR);
                    attempts++;
                } while (!succeeded && attempts < MAX_TRIES);

                if (succeeded)
                {
                    Console.WriteLine("Successfully built webform {0}, took {1} {2}", item.WebFormZNo, attempts, attempts == 1 ? "attempt" : "attempts");
                }else
                {
                    Console.WriteLine("Failed to build webform {0}, took to many attempts",item.WebFormZNo);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to build webform {0}, Check logs for more information",item.WebFormZNo);
            }

        }

        public void InsertScript(WebFormItem item)
        {
            try
            {
                if (item.CustomJavascript == CustomJavascript.None)
                    return;
                string file = string.Format(SCRIPT_FORMAT, domain, item.ConfirmationPage);
                string content = File.ReadAllText(file);
                Console.WriteLine("Inserting script into file: "+ file);
                switch (item.CustomJavascript)
                {
                    case CustomJavascript.None:
                        break;
                    case CustomJavascript.ActionA:
                        content = content.Insert(content.IndexOf(SCRIPT_PLACEMENT), Properties.Resources.ActionA);
                        break;
                    case CustomJavascript.ActionC:
                        content = content.Insert(content.IndexOf(SCRIPT_PLACEMENT), Properties.Resources.ActionC);
                        break;
                    case CustomJavascript.ActionN:
                        content = content.Insert(content.IndexOf(SCRIPT_PLACEMENT), Properties.Resources.ActionN);
                        break;
                    default:
                        break;
                }
                File.WriteAllText(file, content);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
