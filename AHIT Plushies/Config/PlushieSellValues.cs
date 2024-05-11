using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public class PlushieSellValues : BaseConfig
    {
        private readonly Dictionary<string, ConfigEntry<int>> _sellValueList = new();
        private const string SectionPlushies = "Plushie Sell Prices";
        private const string SectionBigPlushies = "Big Plushie Sell Prices";
        private const string SectionSmallPlushies = "Small Plushie Sell Prices";
        private const string SectionWeapons = "Weapon Sell Prices";
        private const int DefaultMin = 40;
        private const int DefaultMax = 80;
        private const int DefaultBigMin = 60;
        private const int DefaultBigMax = 110;
        private const int DefaultSmallMin = 30;
        private const int DefaultSmallMax = 70;
        
        public PlushieSellValues(ConfigFile cfg)
        {
            SetBindings(cfg);
        }

        internal sealed override void SetBindings(ConfigFile cfg)
        {
            _sellValueList["BowKidPlushieMinValue"] = Bind(cfg, SectionPlushies, "Bow Kid Min Value", DefaultMin);
            _sellValueList["BowKidPlushieMaxValue"] = Bind(cfg, SectionPlushies, "Bow Kid Max Value", DefaultMax);
            _sellValueList["CAWPlushieMinValue"] = Bind(cfg, SectionPlushies, "CAW Agent Min Value", DefaultMin);
            _sellValueList["CAWPlushieMaxValue"] = Bind(cfg, SectionPlushies, "CAW Agent Max Value", DefaultMax);
            _sellValueList["ConductorPlushieMinValue"] = Bind(cfg, SectionPlushies, "Conductor Min Value", DefaultMin);
            _sellValueList["ConductorPlushieMaxValue"] = Bind(cfg, SectionPlushies, "Conductor Max Value", DefaultMax);
            _sellValueList["FireSpiritPlushieMinValue"] = Bind(cfg, SectionPlushies, "Fire Spirit Min Value", DefaultMin);
            _sellValueList["FireSpiritPlushieMaxValue"] = Bind(cfg, SectionPlushies, "Fire Spirit Max Value", DefaultMax);
            _sellValueList["FishDudePlushieMinValue"] = Bind(cfg, SectionPlushies, "Fish Dude Min Value", DefaultMin);
            _sellValueList["FishDudePlushieMaxValue"] = Bind(cfg, SectionPlushies, "Fish Dude Max Value", DefaultMax);
            _sellValueList["HatKidPlushieMinValue"] = Bind(cfg, SectionPlushies, "Hat Kid Min Value", DefaultMin);
            _sellValueList["HatKidPlushieMaxValue"] = Bind(cfg, SectionPlushies, "Hat Kid Max Value", DefaultMax);
            _sellValueList["MustacheGirlPlushieMinValue"] = Bind(cfg, SectionPlushies, "Mustache Girl Min Value", DefaultMin);
            _sellValueList["MustacheGirlPlushieMaxValue"] = Bind(cfg, SectionPlushies, "Mustache Girl Max Value", DefaultMax);
            
            _sellValueList["GrandkidPlushieMinValue"] = Bind(cfg, SectionSmallPlushies, "Grandkid Min Value", DefaultSmallMin);
            _sellValueList["GrandkidPlushieMaxValue"] = Bind(cfg, SectionSmallPlushies, "Grandkid Max Value", DefaultSmallMax);
            _sellValueList["MadCrowPlushieMinValue"] = Bind(cfg, SectionSmallPlushies, "Mad Crow Min Value", DefaultSmallMin);
            _sellValueList["MadCrowPlushieMaxValue"] = Bind(cfg, SectionSmallPlushies, "Mad Crow Max Value", DefaultSmallMax);
            _sellValueList["SealPlushieMinValue"] = Bind(cfg, SectionSmallPlushies, "Seal Min Value", DefaultSmallMin);
            _sellValueList["SealPlushieMaxValue"] = Bind(cfg, SectionSmallPlushies, "Seal Max Value", DefaultSmallMax);
            
            _sellValueList["DJGroovesPlushieMinValue"] = Bind(cfg, SectionBigPlushies, "DJ Grooves Min Value", DefaultBigMin);
            _sellValueList["DJGroovesPlushieMaxValue"] = Bind(cfg, SectionBigPlushies, "DJ Grooves Max Value", DefaultBigMax);
            _sellValueList["EmpressPlushieMinValue"] = Bind(cfg, SectionBigPlushies, "Empress Min Value", DefaultBigMin);
            _sellValueList["EmpressPlushieMaxValue"] = Bind(cfg, SectionBigPlushies, "Empress Max Value", DefaultBigMax);
            _sellValueList["MafiaDudePlushieMinValue"] = Bind(cfg, SectionBigPlushies, "Mafia Dude Min Value", DefaultBigMin);
            _sellValueList["MafiaDudePlushieMaxValue"] = Bind(cfg, SectionBigPlushies, "Mafia Dude Max Value", DefaultBigMax);
            _sellValueList["SnatcherPlushieMinValue"] = Bind(cfg, SectionBigPlushies, "Snatcher Min Value", DefaultBigMin);
            _sellValueList["SnatcherPlushieMaxValue"] = Bind(cfg, SectionBigPlushies, "Snatcher Max Value", DefaultBigMax);

            _sellValueList["UmbrellaMinValue"] = Bind(cfg, SectionWeapons, "Umbrella Min Value", DefaultMin);
            _sellValueList["UmbrellaMaxValue"] = Bind(cfg, SectionWeapons, "Umbrella Max Value", DefaultMax);
            _sellValueList["BaseballBatMinValue"] = Bind(cfg, SectionWeapons, "Baseball Bat Min Value", DefaultMin);
            _sellValueList["BaseballBatMaxValue"] = Bind(cfg, SectionWeapons, "Baseball Bat Max Value", DefaultMax);
            _sellValueList["TimePieceMinValue"] = Bind(cfg, SectionWeapons, "Time Piece Bat Min Value", DefaultBigMin);
            _sellValueList["TimePieceMaxValue"] = Bind(cfg, SectionWeapons, "Time Piece Bat Max Value", DefaultBigMax);
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
