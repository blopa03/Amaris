using System.Configuration;

namespace Amaris.DataAccess
{
    class VariableConfig
    {
        protected internal static string UrlClients = ConfigurationManager.AppSettings["url.clients"].ToString();
        protected internal static string UrlPolicies = ConfigurationManager.AppSettings["url.policies"].ToString();
    }
}
