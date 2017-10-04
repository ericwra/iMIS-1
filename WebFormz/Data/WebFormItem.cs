using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFormz
{
    class WebFormItem
    {
        public string WebFormZNo { get; set; }
        public string WebFormZKey { get; set; }
        public string ConfirmationPage { get; set; }
        public CustomJavascript CustomJavascript { get; set; }
    }
    public enum CustomJavascript
    {
        None,
        ActionA,
        ActionC,
        ActionN
    }
}
