using Amaris.Entities;
using Amaris.Repository;

namespace Amaris.BussinessLogic
{
    class ClientsBussinessLogic : IClientsBussinessLogic
    {
        private IClientsRepository clientsRepository { get; set; }
        private IPoliciesRepository policiesRepository { get; set; }
        public ClientsBussinessLogic(IClientsRepository _clientsRepository, IPoliciesRepository _policiesRepository)
        {
            clientsRepository = _clientsRepository;
            policiesRepository = _policiesRepository;

        }
        
        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public Client GetById(string pId)
        {
            return clientsRepository.GetById(pId);
        }

        /// <summary>
        /// Get by name
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Client GetByName(string pName)
        {
            return clientsRepository.GetByName(pName);
        }

        /// <summary>
        /// get by number policy
        /// </summary>
        /// <param name="pNumberPolicy"></param>
        /// <returns></returns>
        public Client GetByNumberPolicy(string pNumberPolicy)
        {
            var policy = policiesRepository.GetByNumberPolicy(pNumberPolicy);
            if (policy != null)
            {
                return clientsRepository.GetById(policy.clientId);
            }
            return null;

        }
    }
}
