namespace SampleUtil
{
    using Unity;
    using System;
    using Processors;

    public sealed class ServiceLocator
    {
        private static readonly Lazy<ServiceLocator> InstanceHolder =
            new Lazy<ServiceLocator>(() => new ServiceLocator());

        private readonly UnityContainer _container;

        private ServiceLocator()
        {
            _container = new UnityContainer();
            RegisterTypes(_container);
        }

        private void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IActionProcessor, AllProcessor>("all");
            container.RegisterType<IActionProcessor, CppProcessor>("cpp");
            container.RegisterType<IActionProcessor, Reversed1Processor>("reversed1");
            container.RegisterType<IActionProcessor, Reversed2Processor>("reversed2");
        }

        public static ServiceLocator Instance => InstanceHolder.Value;

        public T GetService<T>(string serviceName)
        {
            return _container.Resolve<T>(serviceName);
        }
    }
}