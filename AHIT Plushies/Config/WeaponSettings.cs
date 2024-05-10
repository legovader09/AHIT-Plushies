using BepInEx.Configuration;

namespace AHIT_Plushies.Config;

public class WeaponSettings : BaseConfig
{
    private readonly Dictionary<string, ConfigEntry<int>> _weaponsList = new();
    
    public WeaponSettings(ConfigFile cfg)
    {
        SetBindings(cfg);
    }

    internal sealed override void SetBindings(ConfigFile cfg)
    {
        const string description = "Set the damage value of this weapon";
        const string spawnRateDesc = "Set the spawn rate of this weapon";
        _weaponsList["UmbrellaDamage"] = Bind(cfg, "Weapon Settings", "Umbrella Damage", 1, description);
        _weaponsList["BaseballBatDamage"] = Bind(cfg, "Weapon Settings", "Baseball Bat Damage", 1, description);
        _weaponsList["TimePieceDamage"] = Bind(cfg, "Weapon Settings", "Time Piece Damage", 3, description);
        _weaponsList["UmbrellaSpawnRate"] = Bind(cfg, "Weapon Settings", "Umbrella Spawn Rate", 10, spawnRateDesc);
        _weaponsList["BaseballBatSpawnRate"] = Bind(cfg, "Weapon Settings", "Baseball Bat Spawn Rate", 10, spawnRateDesc);
        _weaponsList["TimePieceSpawnRate"] = Bind(cfg, "Weapon Settings", "Time Piece Spawn Rate", 5, spawnRateDesc);
    }

    internal ConfigEntry<int> GetValue(string weapon)
    {
        return _weaponsList.GetValueOrDefault(weapon);
    }
}