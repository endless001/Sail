using Sail.Plugin.Abstractions;
using Sail.Plugin.Context;
using Sail.Plugin.TypeFinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    public class AssemblyPluginProviders : IPlugin
    {
        private readonly string _assemblyPath;
        private  Assembly _assembly;
        private readonly AssemblyPluginOptions _options;
        private PluginAssemblyLoadContext _pluginAssemblyLoadContext;
        private List<TypePluginProviders> _plugins = null;

        public bool IsInitialized { get; private set; }


        public AssemblyPluginProviders(string assemblyPath) : this(assemblyPath, null, null, null)
        {
        }

        public AssemblyPluginProviders(Assembly assembly) : this(null, assembly)
        {
        }

        public AssemblyPluginProviders(string assemblyPath, AssemblyPluginOptions options = null) : this(assemblyPath, null, null, null, null, null,
            options)
        {
        }

        public AssemblyPluginProviders(Assembly assembly, AssemblyPluginOptions options = null) : this(null, assembly, null, null, null, null, options)
        {
        }

        public AssemblyPluginProviders(string assemblyPath, TypeFinderCriteria criteria = null, AssemblyPluginOptions options = null) : this(assemblyPath,
            null, null, null,
            null, criteria, options)
        {
        }

        public AssemblyPluginProviders(string assemblyPath, Action<TypeFinderCriteriaBuilder> configureFinder = null,
            AssemblyPluginOptions options = null) : this(assemblyPath,
            null, null, null, configureFinder, null, options)
        {
        }

        public AssemblyPluginProviders(Assembly assembly, Action<TypeFinderCriteriaBuilder> configureFinder = null,
            AssemblyPluginOptions options = null) : this(null,
            assembly, null, null, configureFinder, null, options)
        {
        }

        public AssemblyPluginProviders(string assemblyPath, Predicate<Type> filter = null, AssemblyPluginOptions options = null) : this(assemblyPath, null,
            filter, null, null, null, options)
        {
        }

        public AssemblyPluginProviders(Assembly assembly, Predicate<Type> filter = null, AssemblyPluginOptions options = null) : this(null, assembly,
            filter, null, null, null, options)
        {
        }

        public AssemblyPluginProviders(string assemblyPath, Dictionary<string, Predicate<Type>> taggedFilters,
            AssemblyPluginOptions options = null) : this(assemblyPath, null, null, taggedFilters, null, null, options)
        {
        }

        public AssemblyPluginProviders(Assembly assembly, Dictionary<string, Predicate<Type>> taggedFilters,
            AssemblyPluginOptions options = null) : this(null, assembly, null, taggedFilters, null, null, options)
        {
        }

        public AssemblyPluginProviders(string assemblyPath = null, Assembly assembly = null, Predicate<Type> filter = null,
            Dictionary<string, Predicate<Type>> taggedFilters = null, Action<TypeFinderCriteriaBuilder> configureFinder = null,
            TypeFinderCriteria criteria = null, AssemblyPluginOptions options = null)
        {
            if (assembly != null)
            {
                _assembly = assembly;
                _assemblyPath = _assembly.Location;
            }
            else if (!string.IsNullOrWhiteSpace(assemblyPath))
            {
                _assemblyPath = assemblyPath;
            }
            else
            {
                throw new ArgumentNullException($"{nameof(assembly)} or {nameof(assemblyPath)} must be set.");
            }

            _options = options ?? new AssemblyPluginOptions();

            SetFilters(filter, taggedFilters, criteria, configureFinder);
        }




        public PluginModel Get(string name, Version version)
        {
            foreach (var pluginCatalog in _plugins)
            {
                var foundPlugin = pluginCatalog.Get(name, version);

                if (foundPlugin == null)
                {
                    continue;
                }

                return foundPlugin;
            }

            return null;
        }

        public List<PluginModel> GetPlugins()
        {
            return _plugins.SelectMany(x => x.GetPlugins()).ToList();
        }

        public async Task Initialize()
        {
            if (!string.IsNullOrWhiteSpace(_assemblyPath) && _assembly == null)
            {
                if (!File.Exists(_assemblyPath))
                {
                    throw new ArgumentException($"Assembly in path {_assemblyPath} does not exist.");
                }
            }

            if (_assembly == null && File.Exists(_assemblyPath) || File.Exists(_assemblyPath) && _pluginAssemblyLoadContext == null)
            {
                _pluginAssemblyLoadContext = new PluginAssemblyLoadContext(_assemblyPath, _options.PluginLoadContextOptions);
                _assembly = _pluginAssemblyLoadContext.Load();
            }

            _plugins = new List<TypePluginProviders>();

            var finder = new TypeFinder();

            var handledPluginTypes = new List<Type>();
            foreach (var typeFinderCriteria in _options.TypeFinderOptions.TypeFinderCriterias)
            {
                var pluginTypes = finder.Find(typeFinderCriteria, _assembly, _pluginAssemblyLoadContext);

                foreach (var type in pluginTypes)
                {
                    if (handledPluginTypes.Contains(type))
                    {
                        // Make sure to create only a single type plugin catalog for each plugin type. 
                        // The type catalog will add all the matching tags
                        continue;
                    }

                    var typePluginProviders = new TypePluginProviders(type,
                        new TypePluginOptions()
                        {
                            PluginNameOptions = _options.PluginNameOptions,
                            TypeFindingContext = _pluginAssemblyLoadContext,
                            TypeFinderOptions = _options.TypeFinderOptions
                        });

                    await typePluginProviders.Initialize();

                    _plugins.Add(typePluginProviders);

                    handledPluginTypes.Add(type);
                }
            }

            IsInitialized = true;
        }

        private void SetFilters(Predicate<Type> filter, Dictionary<string, Predicate<Type>> taggedFilters, TypeFinderCriteria criteria,
            Action<TypeFinderCriteriaBuilder> configureFinder)
        {
            if (_options.TypeFinderOptions == null)
            {
                _options.TypeFinderOptions = new TypeFinderOptions();
            }

            if (_options.TypeFinderOptions.TypeFinderCriterias == null)
            {
                _options.TypeFinderOptions.TypeFinderCriterias = new List<TypeFinderCriteria>();
            }

            if (filter != null)
            {
                var filterCriteria = new TypeFinderCriteria { Query = (context, type) => filter(type) };
                filterCriteria.Tags.Add(string.Empty);

                _options.TypeFinderOptions.TypeFinderCriterias.Add(filterCriteria);
            }

            if (taggedFilters?.Any() == true)
            {
                foreach (var taggedFilter in taggedFilters)
                {
                    var taggedCriteria = new TypeFinderCriteria { Query = (context, type) => taggedFilter.Value(type) };
                    taggedCriteria.Tags.Add(taggedFilter.Key);

                    _options.TypeFinderOptions.TypeFinderCriterias.Add(taggedCriteria);
                }
            }

            if (configureFinder != null)
            {
                var builder = new TypeFinderCriteriaBuilder();
                configureFinder(builder);

                var configuredCriteria = builder.Build();

                _options.TypeFinderOptions.TypeFinderCriterias.Add(configuredCriteria);
            }

            if (criteria != null)
            {
                _options.TypeFinderOptions.TypeFinderCriterias.Add(criteria);
            }

            if (_options.TypeFinderCriterias?.Any() == true)
            {
                foreach (var typeFinderCriteria in _options.TypeFinderCriterias)
                {
                    var crit = typeFinderCriteria.Value;
                    crit.Tags = new List<string>() { typeFinderCriteria.Key };

                    _options.TypeFinderOptions.TypeFinderCriterias.Add(crit);
                }
            }

            if (_options.TypeFinderOptions.TypeFinderCriterias.Any() != true)
            {
                var findAll = TypeFinderCriteriaBuilder
                    .Create()
                    .Tag(string.Empty)
                    .Build();

                _options.TypeFinderOptions.TypeFinderCriterias.Add(findAll);
            }
        }
    }
}
