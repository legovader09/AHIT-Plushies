using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public class GeneralSettings : BaseConfig
    {
        public ConfigEntry<bool> PlushiesRequireBattery { get; private set; }

        public GeneralSettings(ConfigFile cfg) : base(cfg)
        {
            SetBindings(cfg);
        }

        internal override void SetBindings(ConfigFile cfg)
        {
            PlushiesRequireBattery = Bind(cfg, "Miscellaneous", "Should one handed plushies require battery power?", true);
        }
    }
}
