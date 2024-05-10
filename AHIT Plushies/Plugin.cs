using AHIT_Plushies.Config;
using BepInEx;
using HarmonyLib;
using LethalLib.Modules;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AHIT_Plushies
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        private const string ModGuid = "Doomnik.AHITPlushies";
        private const string ModName = "AHIT Plushies";
        private const string ModVersion = "1.0.0.0";
        private GeneralSettings _settings;
        private PlushieSpawnRates _plushieRates;
        private PlushieSellValues _plushieValues;
        private WeaponSettings _weaponSettings;

        private List<Item> _items;
        private readonly List<string> _weaponsList = ["Umbrella", "BaseballBat", "TimePiece"];

        void Awake()
        {
            _settings = new(Config);
            _plushieRates = new(Config);
            _plushieValues = new(Config);
            _weaponSettings = new(Config);

            instance = this;

            var assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "ahitplushscrap");
            var bundle = AssetBundle.LoadFromFile(assetDir);

            _items =
            [
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
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/FishDudePlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/FireSpiritPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/MadCrowPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/MafiaDudePlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/GrandkidPlushie.asset"),
                bundle.LoadAsset<Item>("Assets/AHIT Plushies/TimePiece.asset"),
            ];

            foreach (var item in _items)
            {
                LoadConfigValues(item);
                NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
                Utilities.FixMixerGroups(item.spawnPrefab);
                item.spawnPrefab.GetComponent<GrabbableObject>().customGrabTooltip = $"Grab {item.itemName}";

                if (item.name == "TimePiece")
                {
                    item.spawnPrefab.AddComponent<TimePiece>();
                }
                
                if (_weaponsList.Contains(item.name))
                {
                    SetupWeapon(item);
                    Items.RegisterScrap(item, _weaponSettings.GetValue($"{item.name}SpawnRate").Value, Levels.LevelTypes.All);
                }
                else
                {
                    Items.RegisterScrap(item, _plushieRates.SpawnRateExperimentation.Value, Levels.LevelTypes.ExperimentationLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateAssurance.Value, Levels.LevelTypes.AssuranceLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateVow.Value, Levels.LevelTypes.VowLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateOffense.Value, Levels.LevelTypes.OffenseLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateMarch.Value, Levels.LevelTypes.MarchLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateRend.Value, Levels.LevelTypes.RendLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateDine.Value, Levels.LevelTypes.DineLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateTitan.Value, Levels.LevelTypes.TitanLevel);
                    Items.RegisterScrap(item, _plushieRates.SpawnRateOther.Value, Levels.LevelTypes.All);
                }
            }

            Logger.LogInfo("AHIT Plushies Patched Successfully");
        }

        private void SetupWeapon(Item item)
        {
            var weapon = item.spawnPrefab.GetComponent<Shovel>();
            weapon.shovelHitForce = _weaponSettings.GetValue($"{item.name}Damage").Value;
        }

        private void LoadConfigValues(Item item)
        {
            if (!_weaponsList.Contains(item.name))
            {
                item.requiresBattery = !item.twoHanded && _settings.PlushiesRequireBattery.Value;
                if (item.requiresBattery && _settings.PlushiesSpawnWithRandomCharge.Value)
                {
                    item.spawnPrefab.GetComponent<GrabbableObject>()
                        .insertedBattery.charge = (float)Random.Range(_settings.PlushiesMinimumChargeOnSpawn.Value, 100) / 100;
                }
            }
            item.minValue = (int)(_plushieValues.GetSellValue($"{item.name}MinValue").Value * 2.5);
            item.maxValue = (int)(_plushieValues.GetSellValue($"{item.name}MaxValue").Value * 2.5);
        }
    }
}