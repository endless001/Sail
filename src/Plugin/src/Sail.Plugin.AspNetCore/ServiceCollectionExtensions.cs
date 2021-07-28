using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Sail.Plugin.Abstractions;
using Sail.Plugin.Configuration.Converters;
using Sail.Plugin.Configuration.Loaders;
using Sail.Plugin.Context;
using Sail.Plugin.Providers;
using Sail.Plugin.TypeFinding;

namespace Sail.Plugin.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlugin(this IServiceCollection services, Action<PluginOptions> configure = null)
        {
            if (configure != null)
            {
                services.Configure(configure);
            }

            services.AddHostedService<PluginInitializer>();
            services.AddTransient<PluginProvider>();

            services.TryAddTransient(typeof(IPluginConfigurationLoader), typeof(PluginConfigurationLoader));
            services.AddTransient(typeof(IConfigurationToPluginConverter), typeof(FolderPluginConfigurationConverter));
            services.AddTransient(typeof(IConfigurationToPluginConverter), typeof(AssemblyPluginConfigurationCoverter));

            services.AddConfiguration();

            services.AddSingleton(sp =>
            {
                var result = new List<PluginModel>();
                var catalogs = sp.GetServices<IPlugin>();

                foreach (var catalog in catalogs)
                {
                    var plugins = catalog.GetPlugins();

                    result.AddRange(plugins);
                }

                return result.AsEnumerable();
            });

            var aspNetCoreControllerAssemblyLocation = typeof(Controller).Assembly.Location;

            if (string.IsNullOrWhiteSpace(aspNetCoreControllerAssemblyLocation))
            {
                return services;
            }

            var aspNetCoreLocation = Path.GetDirectoryName(aspNetCoreControllerAssemblyLocation);

            if (PluginLoadContextOptions.Defaults.AdditionalRuntimePaths == null)
            {
                PluginLoadContextOptions.Defaults.AdditionalRuntimePaths = new List<string>();
            }

            if (!PluginLoadContextOptions.Defaults.AdditionalRuntimePaths.Contains(aspNetCoreLocation))
            {
                PluginLoadContextOptions.Defaults.AdditionalRuntimePaths.Add(aspNetCoreLocation);
            }

            return services;
        }

        public static IServiceCollection AddPlugin<TType>(this IServiceCollection services, string dllPath = "") where TType : class
        {
            services.AddPlugin();

            if (string.IsNullOrWhiteSpace(dllPath))
            {
                var entryAssembly = Assembly.GetEntryAssembly();

                if (entryAssembly == null)
                {
                    dllPath = Environment.CurrentDirectory;
                }
                else
                {
                    dllPath = Path.GetDirectoryName(entryAssembly.Location);
                }
            }

            var typeFinderCriteria = TypeFinderCriteriaBuilder.Create()
                .AssignableTo(typeof(TType))
                .Build();

            var catalog = new FolderPluginProviders(dllPath, typeFinderCriteria);
            services.AddPluginCatalog(catalog);

            services.AddPluginType<TType>();

            return services;
        }

        private static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            services.TryAddSingleton<IPlugin>(serviceProvider =>
            {
                var options = serviceProvider.GetService<IOptions<PluginOptions>>().Value;

                if (options.UseConfiguration == false)
                {
                    return new EmptyPluginProviders();
                }

                // Grab all the IPluginCatalogConfigurationLoader implementations to load catalog configurations.
                var loaders = serviceProvider
                    .GetServices<IPluginConfigurationLoader>()
                    .ToList();

                var configuration = serviceProvider.GetService<IConfiguration>();

                var converters = serviceProvider.GetServices<IConfigurationToPluginConverter>().ToList();
                var catalogs = new List<IPlugin>();

                foreach (var loader in loaders)
                {
                    // Load the catalog configurations.
                    var catalogConfigs = loader.GetPluginConfigurations(configuration);

                    if (catalogConfigs?.Any() != true)
                    {
                        continue;
                    }

                    for (var i = 0; i < catalogConfigs.Count; i++)
                    {
                        var item = catalogConfigs[i];
                        var key = $"{options.ConfigurationSection}:{loader.Key}:{i}";

                        // Check if a type is provided.
                        if (string.IsNullOrWhiteSpace(item.Type))
                        {
                            throw new ArgumentException($"A type must be provided for catalog at position {i + 1}");
                        }

                        // Try to find any registered converter that can convert the specified type.
                        var foundConverter = converters.FirstOrDefault(converter => converter.CanConvert(item.Type));

                        if (foundConverter == null)
                        {
                            throw new ArgumentException($"The type provided for Plugin catalog at position {i + 1} is unknown.");
                        }

                        var catalog = foundConverter.Convert(configuration.GetSection(key));

                        catalogs.Add(catalog);
                    }
                }

                return new CompositePluginProviders(catalogs.ToArray());
            });

            return services;
        }

        public static IServiceCollection AddPluginCatalog(this IServiceCollection services, IPlugin pluginCatalog)
        {
            services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IPlugin), pluginCatalog));

            return services;
        }

        public static IServiceCollection AddPluginType<T>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Transient,
            Action<DefaultPluginOption> configureDefault = null)
            where T : class
        {
            var serviceDescriptorEnumerable = new ServiceDescriptor(typeof(IEnumerable<T>), sp =>
            {
                var pluginProvider = sp.GetService<PluginProvider>();
                var result = pluginProvider.GetTypes<T>();

                return result.AsEnumerable();
            }, serviceLifetime);

            var serviceDescriptorSingle = new ServiceDescriptor(typeof(T), sp =>
            {
                var defaultPluginOption = GetDefaultPluginOptions<T>(configureDefault, sp);

                var pluginProvider = sp.GetService<PluginProvider>();
                var result = pluginProvider.GetTypes<T>();

                var defaultType = defaultPluginOption.DefaultType(sp, result.Select(r => r.GetType()));

                return result.FirstOrDefault(r => r.GetType() == defaultType);
            }, serviceLifetime);

            services.Add(serviceDescriptorEnumerable);
            services.Add(serviceDescriptorSingle);

            return services;
        }

        private static DefaultPluginOption GetDefaultPluginOptions<T>(Action<DefaultPluginOption> configureDefault, IServiceProvider sp) where T : class
        {
            var defaultPluginOption = new DefaultPluginOption();

            // If no configuration is provided though action try to get configuration from named options
            if (configureDefault == null)
            {
                var optionsFromMonitor =
                    sp.GetService<IOptionsMonitor<DefaultPluginOption>>().Get(typeof(T).Name);

                if (optionsFromMonitor != null)
                {
                    defaultPluginOption = optionsFromMonitor;
                }
            }
            else
            {
                configureDefault(defaultPluginOption);
            }

            return defaultPluginOption;
        }
    }
}
