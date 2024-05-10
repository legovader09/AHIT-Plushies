using BepInEx.Configuration;

namespace AHIT_Plushies.Config
{
    public class PlushieSpawnRates : BaseConfig
    {
        public ConfigEntry<int> SpawnRateExperimentation;
        public ConfigEntry<int> SpawnRateAssurance;
        public ConfigEntry<int> SpawnRateVow;
        public ConfigEntry<int> SpawnRateOffense;
        public ConfigEntry<int> SpawnRateMarch;
        public ConfigEntry<int> SpawnRateRend;
        public ConfigEntry<int> SpawnRateDine;
        public ConfigEntry<int> SpawnRateTitan;
        public ConfigEntry<int> SpawnRateOther;
        
        public PlushieSpawnRates(ConfigFile cfg)
        {
            SetBindings(cfg);
        }

        internal sealed override void SetBindings(ConfigFile cfg)
        {
            const string description = "Set the spawn rate on this moon";
            SpawnRateExperimentation = Bind(cfg, "Spawn Rates", "Experimentation", 10, description);
            SpawnRateAssurance = Bind(cfg, "Spawn Rates", "Assurance", 10, description);
            SpawnRateVow = Bind(cfg, "Spawn Rates", "Vow", 10, description);
            SpawnRateOffense = Bind(cfg, "Spawn Rates", "Offense", 20, description);
            SpawnRateMarch = Bind(cfg, "Spawn Rates", "March", 20, description);
            SpawnRateRend = Bind(cfg, "Spawn Rates", "Rend", 30, description);
            SpawnRateDine = Bind(cfg, "Spawn Rates", "Dine", 30, description);
            SpawnRateTitan = Bind(cfg, "Spawn Rates", "Titan", 30, description);
            SpawnRateOther = Bind(cfg, "Spawn Rates", "Other Moons", 30, "Set the spawn rate on any other moon");
        }
    }
}
