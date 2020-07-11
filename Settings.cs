using System.Configuration;

namespace ChangePassword
{
    class Settings
    {
        internal static string DomainName { get { return ConfigurationManager.AppSettings["DomainName"]; } }
        internal static string TopPageUrl { get { return ConfigurationManager.AppSettings["TopPageUrl"]; } }
        internal static string TopPageText { get { return ConfigurationManager.AppSettings["TopPageText"]; } }
        internal static string PhoneBookUrl { get { return ConfigurationManager.AppSettings["PhoneBookUrl"]; } }
        internal static string PhoneBookText { get { return ConfigurationManager.AppSettings["PhoneBookText"]; } }
        internal static string Referers { get { return ConfigurationManager.AppSettings["Referers"]; } }
        internal static bool IsTopPageAvailable { get { return !string.IsNullOrEmpty(TopPageUrl); } }
        internal static bool IsPhoneBookAvailable { get { return !string.IsNullOrEmpty(PhoneBookUrl); } }
    }
}