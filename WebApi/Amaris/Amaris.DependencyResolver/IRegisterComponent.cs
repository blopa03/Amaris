using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaris.DependencyResolver
{
    public interface IRegisterComponent
    {
        void RegisterType<TFrom, TTo>(bool withInterception = true) where TTo : TFrom;
        void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = true) where TTo : TFrom;
    }
}
