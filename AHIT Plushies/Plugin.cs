using AHIT_Plushies.Config;
using BepInEx;
using HarmonyLib;
using LethalLib.Modules;
using System.Reflection;
using UnityEngine;

namespace AHIT_Plushies
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string modGUID = "Doomnik.AHITPlushies";
        public const string modName = "AHIT Plushies";
        public const string modVersion = "1.0.0.0";
        public static Plugin instance;
        public Harmony harmony = new Harmony("Doomnik.AHITPlushies");
        public PlushieSpawnRates plushieRates;
        public PlushieSellValues plushieValues;
        public GeneralSettings settings;

        private List<Item> items;
        private List<string> weaponsList = new List<string>() { "Umbrella", "BaseballBat" };

        void Awake()
        {
            plushieRates = new(Config);
            plushieValues = new(Config);
            settings = new(Config);

            instance = this;
            //harmony.PatchAll(typeof(Weapon));

            var assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ahitplushscrap");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            items = new List<Item>
            {
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/HatKidPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/ConductorPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/MustacheGirlPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/CAWPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/SnatcherPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/Umbrella.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/BaseballBat.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/BowKidPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/DJGroovesPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/EmpressPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/SealPlushie.asset"),
            };

            foreach (var item in items)
            {
                LoadConfigValues(item);
                NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
                Utilities.FixMixerGroups(item.spawnPrefab);
                Items.RegisterScrap(item, plushieRates.SpawnRateExperimentation.Value, Levels.LevelTypes.ExperimentationLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateAssurance.Value, Levels.LevelTypes.AssuranceLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateVow.Value, Levels.LevelTypes.VowLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateOffense.Value, Levels.LevelTypes.OffenseLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateMarch.Value, Levels.LevelTypes.MarchLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateRend.Value, Levels.LevelTypes.RendLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateDine.Value, Levels.LevelTypes.DineLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateTitan.Value, Levels.LevelTypes.TitanLevel);
                Items.RegisterScrap(item, plushieRates.SpawnRateOther.Value, Levels.LevelTypes.All);
                if (weaponsList.Contains(item.name)) item.spawnPrefab.GetComponent<Shovel>();
            }

            Logger.LogInfo("AHIT Plushies Patched Successfully");
        }

        private void LoadConfigValues(Item item)
        {
            item.requiresBattery = !weaponsList.Contains(item.name) && !item.twoHanded && settings.PlushiesRequireBattery.Value;
            item.minValue = (int)(plushieValues.GetPlushieValue($"{item.name}MinValue").Value * 2.5);
            item.maxValue = (int)(plushieValues.GetPlushieValue($"{item.name}MaxValue").Value * 2.5);
        }
    }
}