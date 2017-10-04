using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormz.Interfaces
{
    interface IBrowser
    {
        void Click(string xpath);
        void SendKeys(string xpath, string input);
        void GoToUrl(string url);
        bool IsChecked(string xpath);
        string GetText(string xpath);
        string GetPageSource();
        string GetTitle();

    }
}
