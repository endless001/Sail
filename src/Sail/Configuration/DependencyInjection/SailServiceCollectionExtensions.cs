using Microsoft.Extensions.DependencyInjection;

namespace Sail.Configuration.DependencyInjection
{
    public static class SailServiceCollectionExtensions
    {
        public static ISailBuilder AddSailBuilder(this IServiceCollection services)
        {
            return new SailBuilder(services);
        }

        public static ISailBuilder AddSail(this IServiceCollection services)
        {
            var builder = services.AddSailBuilder();
            return builder;
        }
    }
}