using Amaris.DependencyResolver;
using System.ComponentModel.Composition;

namespace Amaris.BussinessLogic
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IClientsBussinessLogic, ClientsBussinessLogic>();
            registerComponent.RegisterType<IPoliciesBussinessLogic, PoliciesBussinessLogic>();
        }
    }
}
