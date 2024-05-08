using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public class PlushieSellValues : BaseConfig
    {
        public Dictionary<string, ConfigEntry<int>> sellValueList = new Dictionary<string, ConfigEntry<int>>();

        public PlushieSellValues(ConfigFile cfg) : base(cfg)
        {
            SetBindings(cfg);
        }

        internal int CalculateScrapValue(int value) => (int)Math.Round(value * 2.5);

        internal override void SetBindings(ConfigFile cfg)
        {
            var sectionPlushies = "Plushie Sell Prices";
            var sectionMisc = "Miscellaneous Sell Prices";
            var defaultMin = 50;
            var defaultMax = 100;
            sellValueList["HatKidPlushieMinValue"] = Bind(cfg, sectionPlushies, "Hat Kid Min Value", defaultMin);
            sellValueList["HatKidPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Hat Kid Max Value", defaultMax);
            sellValueList["ConductorPlushieMinValue"] = Bind(cfg, sectionPlushies, "Conductor Min Value", defaultMin);
            sellValueList["ConductorPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Conductor Max Value", defaultMax);
            sellValueList["MustacheGirlPlushieMinValue"] = Bind(cfg, sectionPlushies, "Mustache Girl Min Value", defaultMin);
            sellValueList["MustacheGirlPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Mustache Girl Max Value", defaultMax);
            sellValueList["CAWPlushieMinValue"] = Bind(cfg, sectionPlushies, "CAW Agent Min Value", defaultMin);
            sellValueList["CAWPlushieMaxValue"] = Bind(cfg, sectionPlushies, "CAW Agent Max Value", defaultMax);
            sellValueList["BowKidPlushieMinValue"] = Bind(cfg, sectionPlushies, "Bow Kid Min Value", defaultMin);
            sellValueList["BowKidPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Bow Kid Max Value", defaultMax);
            sellValueList["SealPlushieMinValue"] = Bind(cfg, sectionPlushies, "Seal Min Value", defaultMin);
            sellValueList["SealPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Seal Max Value", defaultMax);

            sellValueList["SnatcherPlushieMinValue"] = Bind(cfg, sectionPlushies, "Snatcher Min Value", 90);
            sellValueList["SnatcherPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Snatcher Max Value", 140);
            sellValueList["DJGroovesPlushieMinValue"] = Bind(cfg, sectionPlushies, "DJ Grooves Min Value", 90);
            sellValueList["DJGroovesPlushieMaxValue"] = Bind(cfg, sectionPlushies, "DJ Grooves Max Value", 140);
            sellValueList["EmpressPlushieMinValue"] = Bind(cfg, sectionPlushies, "Empress Min Value", 90);
            sellValueList["EmpressPlushieMaxValue"] = Bind(cfg, sectionPlushies, "Empress Max Value", 140);

            sellValueList["UmbrellaMinValue"] = Bind(cfg, sectionMisc, "Umbrella Min Value", defaultMin);
            sellValueList["UmbrellaMaxValue"] = Bind(cfg, sectionMisc, "Umbrella Max Value", defaultMax);
            sellValueList["BaseballBatMinValue"] = Bind(cfg, sectionMisc, "Baseball Bat Min Value", defaultMin);
            sellValueList["BaseballBatMaxValue"] = Bind(cfg, sectionMisc, "Baseball Bat Max Value", defaultMax);
        }

        internal ConfigEntry<int> GetPlushieValue(string propertyName)
        {
            return sellValueList.ContainsKey(propertyName) ? sellValueList[propertyName] : null;
        }

        internal override ConfigEntry<T> Bind<T>(ConfigFile cfg, string section, string key, T defaultValue)
        {
            var isMin = key.Contains("Min");
            var configItem = cfg.Bind(
                section: section,
                key: key,
                defaultValue: defaultValue,
                configDescription: new ConfigDescription($"Set the {(isMin ? "minimum" : "maximum")} sell value of this plushie.", new AcceptableValueRange<int>(0, 1000))
            );

            return configItem;
        }
    }
}
