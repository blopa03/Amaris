using Amaris.DependencyResolver;
using System.ComponentModel.Composition;

namespace Amaris.DataAccess
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IClientsDataAccess, ClientsDataAccess>();
            registerComponent.RegisterType<IPoliciesDataAccess, PoliciesDataAccess>();
        }
    }
}
