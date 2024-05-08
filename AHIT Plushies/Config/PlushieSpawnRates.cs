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

        public PlushieSpawnRates(ConfigFile cfg) : base(cfg)
        {
            SetBindings(cfg);
        }

        internal override void SetBindings(ConfigFile cfg)
        {
            SpawnRateExperimentation = Bind(cfg, "Spawn Rates", "Experimentation", 10);
            SpawnRateAssurance = Bind(cfg, "Spawn Rates", "Assurance", 10);
            SpawnRateVow = Bind(cfg, "Spawn Rates", "Vow", 10);
            SpawnRateOffense = Bind(cfg, "Spawn Rates", "Offense", 20);
            SpawnRateMarch = Bind(cfg, "Spawn Rates", "March", 20);
            SpawnRateRend = Bind(cfg, "Spawn Rates", "Rend", 30);
            SpawnRateDine = Bind(cfg, "Spawn Rates", "Dine", 30);
            SpawnRateTitan = Bind(cfg, "Spawn Rates", "Titan", 30);
            SpawnRateOther = Bind(cfg, "Spawn Rates", "Other Moons", 30);
        }
    }
}
