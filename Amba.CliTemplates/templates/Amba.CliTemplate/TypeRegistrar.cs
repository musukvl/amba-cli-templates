using System;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Amba.CliTemplate
{
    internal sealed class TypeRegistrar : ITypeRegistrar
    {
        private readonly IServiceCollection _services;

        public TypeRegistrar(IServiceCollection services)
        {
            _services = services;
        }

        public ITypeResolver Build()
        {
            return new TypeResolver(_services.BuildServiceProvider());
        }

        public void Register(Type service, Type implementation)
        {
            _services.AddSingleton(service, implementation);
        }

        public void RegisterInstance(Type service, object implementation)
        {
            _services.AddSingleton(service, implementation);
        }

        public void RegisterLazy(Type service, Func<object> factory)
        {
            _services.AddSingleton(service, _ => factory());
        }
    }

    internal sealed class TypeResolver : ITypeResolver, IDisposable
    {
        private readonly ServiceProvider _serviceProvider;

        public TypeResolver(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object Resolve(Type type)
        {
            return ActivatorUtilities.GetServiceOrCreateInstance(_serviceProvider, type);
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}