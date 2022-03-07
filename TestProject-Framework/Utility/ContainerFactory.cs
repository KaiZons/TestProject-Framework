using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace TestProject_Framework.Utility
{
    public class ContainerFactory
    {
        private static IUnityContainer m_container;
        public static IUnityContainer BuildContainer()
        { 
            return m_container;
        }

        static ContainerFactory()
        {
            // 使用微软封装的类读取配置文件
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CfgFiles\\Unity.config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            // 将配置节点强制转换成UnityConfigurationSection
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            m_container = new UnityContainer();
            // 配置容器
            section.Configure(m_container, "WebApiContainer");

        }
    }
}