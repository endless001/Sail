namespace Sail.Plugin.Abstractions
{
    public class PluginOptions
    {
        public bool UseConfiguration { get; set; } = true;
        public string ConfigurationSection { get; set; } = "Plugin";
    }
}
