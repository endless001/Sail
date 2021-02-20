using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sail.Configuration.DependencyInjection
{
    public class SailBuilder:ISailBuilder
    {
        public SailBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }
        public IServiceCollection Services { get; }
    }
}