using Microsoft.Extensions.DependencyInjection;
using System;

namespace ReCapProject.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        public void Load(IServiceCollection serviceCollection);
    }
}