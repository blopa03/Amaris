using System.Collections.Generic;

namespace Amaris.Entities
{
    public class Client
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }

    public class Clients
    {
        public List<Client> clients { get; set; }
    }

}
