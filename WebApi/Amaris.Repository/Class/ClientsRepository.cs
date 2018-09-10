using Amaris.DataAccess;
using Amaris.Entities;
using System.Linq;

namespace Amaris.Repository
{
    class ClientsRepository : IClientsRepository
    {
        private IClientsDataAccess clientsDataAccess { get; set; }

        public ClientsRepository(IClientsDataAccess _clientsDataAccess)
        {
            clientsDataAccess = _clientsDataAccess;
        }
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        private Clients GetAll()
        {
            return clientsDataAccess.GetAll();
        }

        /// <summary>
        /// Get one client by id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public Client GetById(string pId)
        {
            var response = GetAll();
            if (response!=null)
            {
                return response.clients.Where(x => x.id == pId).ToList().FirstOrDefault();
            }
            return null;
        }

        /// <summary>
        /// Get one client by name
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Client GetByName(string pName)
        {
            var response = GetAll();
            if (response != null)
            {
                return response.clients.Where(x => x.name == pName).ToList().FirstOrDefault();
            }
            return null;
        }

    }
}
