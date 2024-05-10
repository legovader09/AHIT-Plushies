using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public class GeneralSettings : BaseConfig
    {
        public ConfigEntry<bool> PlushiesRequireBattery;
        
        public GeneralSettings(ConfigFile cfg)
        {
            SetBindings(cfg);
        }
        
        internal sealed override void SetBindings(ConfigFile cfg)
        {
            PlushiesRequireBattery = Bind(cfg, "Miscellaneous", "Should one handed plushies require battery power?", true);
        }
    }
}
