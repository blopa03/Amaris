using Amaris.Entities;
using Newtonsoft.Json;
using System.Net;

namespace Amaris.DataAccess
{
    class ClientsDataAccess : IClientsDataAccess
    {
        /// <summary>
        /// Get All clients by url
        /// </summary>
        /// <returns></returns>
        public Clients GetAll()
        {
            var urlClients = VariableConfig.UrlClients;

            if (!string.IsNullOrEmpty(urlClients))
            {
                var json = new WebClient().DownloadString(urlClients);
                return JsonConvert.DeserializeObject<Clients>(json);
            }
            return null;
        }
    }
}
