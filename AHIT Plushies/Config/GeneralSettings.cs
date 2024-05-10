using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public class GeneralSettings : BaseConfig
    {
        public ConfigEntry<bool> PlushiesRequireBattery;
        public ConfigEntry<bool> PlushiesSpawnWithRandomCharge;
        public ConfigEntry<int> PlushiesMinimumChargeOnSpawn;
        
        public GeneralSettings(ConfigFile cfg)
        {
            SetBindings(cfg);
        }
        
        internal sealed override void SetBindings(ConfigFile cfg)
        {
            PlushiesRequireBattery = Bind(cfg, "General", "Should one handed plushies require battery power", true);
            PlushiesSpawnWithRandomCharge = Bind(cfg, "General", "Should plushies spawn with random battery charge", true);
            PlushiesMinimumChargeOnSpawn = Bind(cfg, "General", "Minimum random spawn charge", 20);
        }
    }
}
