using Amaris.Entities;
using System.Collections.Generic;

namespace Amaris.BussinessLogic
{
    public interface IPoliciesBussinessLogic
    {        
        List<Policy> GetByIdClient(string pIdClient);        
    }
}
