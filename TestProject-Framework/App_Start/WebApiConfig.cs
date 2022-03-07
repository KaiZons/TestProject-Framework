using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestProject_Framework.Utility;

namespace TestProject_Framework
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // 将容器与WebApi框架融合：
            // 方式：step1：创建容器（跟正常IOC一样，写配置文件，然后创建IUnityContainer实例；
            // step2：实现IDependencyResolver接口，里面用创建的容器去实现接口方法）
            // step3: 将config.DependencyResolver换成自己实现的Resolver
            config.DependencyResolver = new UnityDependencyResolver(ContainerFactory.BuildContainer());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
