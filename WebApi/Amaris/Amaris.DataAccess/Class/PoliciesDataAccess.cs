using Newtonsoft.Json;
using System.Net;
using Amaris.Entities;

namespace Amaris.DataAccess
{
    class PoliciesDataAccess : IPoliciesDataAccess
    {
        /// <summary>
        /// Get all policies by url
        /// </summary>
        /// <returns></returns>
        public Policies GetAll()
        {
            var urlPolicies = VariableConfig.UrlPolicies;

            if (!string.IsNullOrEmpty(urlPolicies))
            {
                var json = new WebClient().DownloadString(urlPolicies);
                return JsonConvert.DeserializeObject<Policies>(json);
            }
            return null;
        }
    }
}
