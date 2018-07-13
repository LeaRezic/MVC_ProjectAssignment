using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RWA_MVC_LeaRezic.BLL
{
    public static class Utils
    {
        public static string GetCleanTitleString(string userInput)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput.Trim().ToLower());
        }
        
        public static string GetCleanOrDummyString(string s)
        {
            return string.IsNullOrEmpty(s) ? "DummyText" : s.Trim().ToLower();
        }

        public static string CheckIfNull(string s)
        {
            return string.IsNullOrEmpty(s) ? "" : s;
        }

    }
}