using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public abstract class BaseConfig
    {
        internal abstract void SetBindings(ConfigFile cfg);
        internal virtual ConfigEntry<T> Bind<T>(ConfigFile cfg, string section, string key, T defaultValue, string description = "")
        {
            return cfg.Bind(
                section: section,
                key: key,
                defaultValue: defaultValue,
                configDescription: new(
                    description, typeof(T) != typeof(bool) ? new AcceptableValueRange<int>(0, 100) : null
                )
            );
        }
    }
}