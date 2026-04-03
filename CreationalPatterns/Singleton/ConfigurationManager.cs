namespace CreationalPatterns.Singleton;

/// <summary>
/// Implémentation thread-safe du pattern Singleton
/// Utilise l'initialisation lazy avec Lazy<T> (.NET)
/// </summary>
public sealed class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> _instance =
        new(() => new ConfigurationManager());

    private readonly Dictionary<string, string> _settings;

    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>
        {
            { "AppName", "Design Patterns Demo" },
            { "Version", "1.0.0" },
            { "Environment", "Development" }
        };
    }

    public static ConfigurationManager Instance => _instance.Value;

    public string GetSetting(string key)
    {
        return _settings.TryGetValue(key, out var value) ? value : string.Empty;
    }

    public void SetSetting(string key, string value)
    {
        _settings[key] = value;
    }

    public void DisplayAllSettings()
    {
        Console.WriteLine("=== Configuration Settings ===");
        foreach (var setting in _settings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}
