using Amaris.DependencyResolver;
using System.ComponentModel.Composition;

namespace Amaris.Repository
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IClientsRepository, ClientsRepository>();
            registerComponent.RegisterType<IPoliciesRepository, PoliciesRepository>();
        }
    }
}
