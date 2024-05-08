using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public abstract class BaseConfig(ConfigFile cfg)
    {
        internal abstract void SetBindings(ConfigFile cfg);
        internal virtual ConfigEntry<T> Bind<T>(ConfigFile cfg, string section, string key, T defaultValue)
        {
            return cfg.Bind(
                section: section,
                key: key,
                defaultValue: defaultValue,
                configDescription: new ConfigDescription
                (
                    $"Set the spawn weight of plushies on {key}.", typeof(T) != typeof(bool) ? new AcceptableValueRange<int>(0, 100) : null
                )
            );
        }
    }
}