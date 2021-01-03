using Microsoft.Extensions.DependencyInjection;

namespace Sail.Configuration.DependencyInjection
{
    public interface ISailBuilder
    {
        IServiceCollection Services { get; }
    }
}