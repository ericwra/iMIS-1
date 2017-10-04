using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebFormz.Helpers
{
    static class Parser
    {

        public static bool Match(string input,string pattern)
        {
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
