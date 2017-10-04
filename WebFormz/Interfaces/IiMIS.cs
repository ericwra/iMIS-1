using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormz.Interfaces
{
    interface IiMIS
    {
        bool Login(string username, string password);
        void BuildWebForm(WebFormItem webForm);
        void InsertScript(WebFormItem webForm);

    }
}
