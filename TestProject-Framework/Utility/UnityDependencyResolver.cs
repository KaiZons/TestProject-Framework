using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace TestProject_Framework.Utility
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer m_container = null;
        public UnityDependencyResolver(IUnityContainer container)
        {
            m_container = container;
        }
        public IDependencyScope BeginScope()
        {
            return new UnityDependencyResolver(m_container.CreateChildContainer());// 创建子容器，不会再读配置文件
        }

        public void Dispose()
        {
            m_container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return m_container.Resolve(serviceType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return m_container.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}