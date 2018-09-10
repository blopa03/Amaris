using Amaris.DataAccess;
using Amaris.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Amaris.Repository
{
    class PoliciesRepository : IPoliciesRepository
    {
        private IPoliciesDataAccess policiesDataAccess { get; set; }
        public PoliciesRepository(IPoliciesDataAccess _policiesDataAccess)
        {
            policiesDataAccess = _policiesDataAccess;
        }

        /// <summary>
        /// Get list policies all
        /// </summary>
        /// <returns></returns>
        private Policies GetAll()
        {
            return policiesDataAccess.GetAll();
        }

        /// <summary>
        /// Get list policies by id client.
        /// </summary>
        /// <param name="pIdClient"></param>
        /// <returns></returns>
        public List<Policy> GetByIdClient(string pIdClient)
        {
            var response = GetAll();            
            return response.policies.Where(x => x.clientId == pIdClient).ToList();
        }

        /// <summary>
        /// Get one policy bye number policy
        /// </summary>
        /// <param name="pNumberPoliciy"></param>
        /// <returns></returns>
        public Policy GetByNumberPolicy(string pNumberPoliciy)
        {
            var response = GetAll();
            return response.policies.Where(x => x.id == pNumberPoliciy).ToList().FirstOrDefault();
        }
    }
}
