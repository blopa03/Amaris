using Amaris.Entities;
using System.Collections.Generic;

namespace Amaris.Repository
{
    public interface IPoliciesRepository
    {     
        List<Policy> GetByIdClient(string pIdClient);
        Policy GetByNumberPolicy(string pNumberPoliciy);
    }
}
