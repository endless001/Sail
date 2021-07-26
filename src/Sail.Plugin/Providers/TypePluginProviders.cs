using Sail.Plugin.Abstractions;
using Sail.Plugin.Context;
using Sail.Plugin.TypeFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    class TypePluginProviders : IPlugin
    {
        private readonly Type _pluginType;
        private readonly TypePluginOptions _options;
        private PluginModel _plugin;
        public bool IsInitialized { get; private set; }

        public TypePluginProviders(Type pluginType) : this(pluginType, null, null, null)
        {
        }

        public TypePluginProviders(Type pluginType, PluginNameOptions nameOptions) : this(pluginType, null, nameOptions, null)
        {
        }

        public TypePluginProviders(Type pluginType, Action<PluginNameOptions> configure) : this(pluginType, configure, null, null)
        {
        }

        public TypePluginProviders(Type pluginType, TypePluginOptions options) : this(pluginType, null, null, options)
        {
        }

        public TypePluginProviders(Type pluginType, Action<PluginNameOptions> configure, PluginNameOptions nameOptions, TypePluginOptions options)
        {
            if (pluginType == null)
            {
                throw new ArgumentNullException(nameof(pluginType));
            }

            _pluginType = pluginType;
            _options = options ?? new TypePluginOptions();

            if (_options.TypeFinderCriterias == null)
            {
                _options.TypeFinderCriterias = new Dictionary<string, TypeFinderCriteria>();
            }

            if (_options.TypeFinderCriterias.Any() != true)
            {
                _options.TypeFinderCriterias.Add(string.Empty, new TypeFinderCriteria() { Query = (context, type) => true });
            }

            if (_options.TypeFindingContext == null)
            {
                _options.TypeFindingContext = new PluginAssemblyLoadContext(pluginType.Assembly);
            }

            if (_options.TypeFinderOptions == null)
            {
                _options.TypeFinderOptions = new TypeFinderOptions();
            }

            if (_options.TypeFinderOptions.TypeFinderCriterias?.Any() != true)
            {
                _options.TypeFinderOptions.TypeFinderCriterias = new List<TypeFinderCriteria>();

                if (_options.TypeFinderCriterias?.Any() == true)
                {
                    foreach (var typeFinderCriteria in _options.TypeFinderCriterias)
                    {
                        var typeFinder = typeFinderCriteria.Value;
                        typeFinder.Tags = new List<string>() { typeFinderCriteria.Key };

                        _options.TypeFinderOptions.TypeFinderCriterias.Add(typeFinder);
                    }
                }
            }

            if (configure == null && nameOptions == null)
            {
                return;
            }

            var naming = nameOptions ?? new PluginNameOptions();
            configure?.Invoke(naming);

            _options.PluginNameOptions = naming;
        }



        public PluginModel Get(string name, Version version)
        {
            if (!string.Equals(name, _plugin.Name, StringComparison.InvariantCultureIgnoreCase) ||
                version != _plugin.Version)
            {
                return null;
            }

            return _plugin;
        }

        public List<PluginModel> GetPlugins()
        {
            return new List<PluginModel>() { _plugin };
        }

        public Task Initialize()
        {
            var namingOptions = _options.PluginNameOptions;
            var version = namingOptions.PluginVersionGenerator(namingOptions, _pluginType);
            var pluginName = namingOptions.PluginNameGenerator(namingOptions, _pluginType);
            var description = namingOptions.PluginDescriptionGenerator(namingOptions, _pluginType);
            var productVersion = namingOptions.PluginProductVersionGenerator(namingOptions, _pluginType);

            var tags = new List<string>();
            var finder = new TypeFinder();

            foreach (var typeFinderCriteria in _options.TypeFinderOptions.TypeFinderCriterias)
            {
                var isMatch = finder.IsMatch(typeFinderCriteria, _pluginType, _options.TypeFindingContext);

                if (isMatch)
                {
                    if (typeFinderCriteria.Tags?.Any() == true)
                    {
                        tags.AddRange(typeFinderCriteria.Tags);
                    }
                }
            }

            _plugin = new PluginModel(_pluginType.Assembly, _pluginType, pluginName, version, this, description, productVersion,string.Empty,tags);
            IsInitialized = true;
            return Task.CompletedTask;
        }
    }
}
