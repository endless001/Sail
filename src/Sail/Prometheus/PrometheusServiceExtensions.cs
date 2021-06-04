using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Telemetry.Consumption;

namespace Sail.Prometheus
{
   public static class PrometheusServiceExtensions
    {
      public static IServiceCollection AddPrometheusProxyMetrics(this IServiceCollection services)
      {
        services.AddTelemetryListeners();
        services.AddSingleton<IProxyMetricsConsumer, PrometheusProxyMetrics>();
        return services;
      }
      public static IServiceCollection AddPrometheusDnsMetrics(this IServiceCollection services)
      {
        services.AddTelemetryListeners();
        services.AddSingleton<INameResolutionMetricsConsumer, PrometheusDnsMetrics>();
        return services;
      }
      public static IServiceCollection AddPrometheusKestrelMetrics(this IServiceCollection services)
      {
        services.AddTelemetryListeners();
        services.AddSingleton<IKestrelMetricsConsumer, PrometheusKestrelMetrics>();
        return services;
      }

      public static IServiceCollection AddPrometheusOutboundHttpMetrics(this IServiceCollection services)
      {
        services.AddTelemetryListeners();
        services.AddSingleton<IHttpMetricsConsumer, PrometheusOutboundHttpMetrics>();
        return services;
      }
      public static IServiceCollection AddPrometheusSocketsMetrics(this IServiceCollection services)
      {
        services.AddTelemetryListeners();
        services.AddSingleton<ISocketsMetricsConsumer, PrometheusSocketMetrics>();
        return services;
      }
      public static IServiceCollection AddAllPrometheusMetrics(this IServiceCollection services)
      {
        services.AddPrometheusProxyMetrics();
        services.AddPrometheusDnsMetrics();
        services.AddPrometheusKestrelMetrics();
        services.AddPrometheusOutboundHttpMetrics();
        services.AddPrometheusSocketsMetrics();
        return services;
      }
    }
}
