using Amaris.Entities;

namespace Amaris.BussinessLogic
{
    public interface IClientsBussinessLogic
    {        
        Client GetById(string pId);
        Client GetByName(string pName);
        Client GetByNumberPolicy(string pNumberPolicy);
    }
}
