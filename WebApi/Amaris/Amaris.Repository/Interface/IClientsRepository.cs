using Amaris.Entities;

namespace Amaris.Repository
{
    public interface IClientsRepository
    {        
        Client GetById(string pId);
        Client GetByName(string pName);        
    }
}
