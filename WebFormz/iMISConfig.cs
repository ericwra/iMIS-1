using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WebFormz
{
    static class iMISConfig
    {
        public static string Domain { get { return ConfigurationManager.AppSettings["domain"]; } }
        public static string LoginURL { get { return "http://{0}/Staff"; } }
        public static string WebFormURL { get { return "http://{0}/iMIS/WebFormZ/WebFormZ.aspx?hkey=4641c1bd-436b-47ad-91f2-08c515eab5ad&iUniformKey={1}"; } }
        public static string UsernameTextBox { get { return "//*[@id='ctl00_TemplateBody_WebPartManager1_gwpciSignIn_ciSignIn_signInUserName']"; } }
        public static string PasswordTextBox { get { return "//*[@id='ctl00_TemplateBody_WebPartManager1_gwpciSignIn_ciSignIn_signInPassword']"; } }
        public static string SignInButton { get { return "//*[@id='ctl00_TemplateBody_WebPartManager1_gwpciSignIn_ciSignIn_SubmitButton']"; } }
        public static string CmsTab { get{ return "//*[@id='ctl00_TemplateBody_Forms_TabStrip']/div/ul/li[8]"; } }
        public static string ConfirmationPageCheckBox { get { return "//*[@id='ctl00_TemplateBody_Forms_WebFormZWCM_WCM_WebFormZConfirmationContentToCreateCheckBox_CheckBoxSet']"; } }
        public static string SaveButon { get { return "//*[@id='ctl00_SaveButton']"; } }
        public static string BuildButton { get { return "//*[@id='ctl00_TemplateBody_Forms_ButtonStartAsynchProcess']"; } }
    }
}
