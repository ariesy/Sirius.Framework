using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.ServiceLocation;

namespace Sirius.Common.Ioc
{
    public class IocContainer
    {
        public static IocContainer Current { get; private set; }

        private IUnityContainer _innerContainer;

        static IocContainer()
        {
            Current = new IocContainer();
        }

        private IocContainer()
        {
            _innerContainer = new UnityContainer();
        }

        public void LoadConfiguration(string containerName = null)
        {
            if (containerName == null)
            {
                _innerContainer.LoadConfiguration();
            }
            else
            {
                _innerContainer.LoadConfiguration(containerName);
            }
        }

        public T Resolve<T>()
        {
            return _innerContainer.Resolve<T>();
        }
    }
}
