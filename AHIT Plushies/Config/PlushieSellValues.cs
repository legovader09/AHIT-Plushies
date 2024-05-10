using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public class PlushieSellValues : BaseConfig
    {
        private readonly Dictionary<string, ConfigEntry<int>> _sellValueList = new();
        
        public PlushieSellValues(ConfigFile cfg)
        {
            SetBindings(cfg);
        }

        internal sealed override void SetBindings(ConfigFile cfg)
        {
            const string sectionPlushies = "Plushie Sell Prices";
            const string sectionMisc = "Weapon Sell Prices";
            const int defaultMin = 50;
            const int defaultMax = 100;
            _sellValueList["HatKidPlushieMinValue"] = Bind(cfg, sectionPlushies, "Hat Kid Min Value", defaultMin);
            _sellValueList["HatKidPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Hat Kid Max Value", defaultMax);
            _sellValueList["ConductorPlushieMinValue"] = Bind(cfg, sectionPlushies, "Conductor Min Value", defaultMin);
            _sellValueList["ConductorPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Conductor Max Value", defaultMax);
            _sellValueList["MustacheGirlPlushieMinValue"] = Bind(cfg, sectionPlushies, "Mustache Girl Min Value", defaultMin);
            _sellValueList["MustacheGirlPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Mustache Girl Max Value", defaultMax);
            _sellValueList["CAWPlushieMinValue"] = Bind(cfg, sectionPlushies, "CAW Agent Min Value", defaultMin);
            _sellValueList["CAWPlushieMaxValue"] = Bind(cfg, sectionPlushies, "CAW Agent Max Value", defaultMax);
            _sellValueList["BowKidPlushieMinValue"] = Bind(cfg, sectionPlushies, "Bow Kid Min Value", defaultMin);
            _sellValueList["BowKidPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Bow Kid Max Value", defaultMax);
            _sellValueList["SealPlushieMinValue"] = Bind(cfg, sectionPlushies, "Seal Min Value", defaultMin);
            _sellValueList["SealPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Seal Max Value", defaultMax);

            _sellValueList["SnatcherPlushieMinValue"] = Bind(cfg, sectionPlushies, "Snatcher Min Value", 90);
            _sellValueList["SnatcherPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Snatcher Max Value", 140);
            _sellValueList["DJGroovesPlushieMinValue"] = Bind(cfg, sectionPlushies, "DJ Grooves Min Value", 90);
            _sellValueList["DJGroovesPlushieMaxValue"] = Bind(cfg, sectionPlushies, "DJ Grooves Max Value", 140);
            _sellValueList["EmpressPlushieMinValue"] = Bind(cfg, sectionPlushies, "Empress Min Value", 90);
            _sellValueList["EmpressPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Empress Max Value", 140);

            _sellValueList["UmbrellaMinValue"] = Bind(cfg, sectionMisc, "Umbrella Min Value", defaultMin);
            _sellValueList["UmbrellaMaxValue"] = Bind(cfg, sectionMisc, "Umbrella Max Value", defaultMax);
            _sellValueList["BaseballBatMinValue"] = Bind(cfg, sectionMisc, "Baseball Bat Min Value", defaultMin);
            _sellValueList["BaseballBatMaxValue"] = Bind(cfg, sectionMisc, "Baseball Bat Max Value", defaultMax);
        }

        internal ConfigEntry<int> GetSellValue(string propertyName)
        {
            return _sellValueList.GetValueOrDefault(propertyName);
        }

        internal override ConfigEntry<T> Bind<T>(ConfigFile cfg, string section, string key, T defaultValue, string description = "")
        {
            var isMin = key.Contains("Min");
            var configItem = cfg.Bind(
                section: section,
                key: key,
                defaultValue: defaultValue,
                configDescription: new($"Set the {(isMin ? "minimum" : "maximum")} sell value of this plushie.", new AcceptableValueRange<int>(0, 1000))
            );

            return configItem;
        }
    }
}
