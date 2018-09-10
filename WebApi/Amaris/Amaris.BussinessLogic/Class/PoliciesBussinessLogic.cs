using Amaris.Entities;
using Amaris.Repository;
using System.Collections.Generic;

namespace Amaris.BussinessLogic
{
    class PoliciesBussinessLogic : IPoliciesBussinessLogic
    {
        private IPoliciesRepository policiesRepository { get; set; }
        private IClientsRepository clientsRepository { get; set; }
        public PoliciesBussinessLogic(IClientsRepository _clientsRepository, IPoliciesRepository _policiesRepository)
        {
            clientsRepository = _clientsRepository;
            policiesRepository = _policiesRepository;
        }       

        /// <summary>
        /// Get by client id
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <returns></returns>
        public List<Policy> GetByIdClient(string pIdClient)
        {
            return policiesRepository.GetByIdClient(pIdClient);
        }        
    }
}
