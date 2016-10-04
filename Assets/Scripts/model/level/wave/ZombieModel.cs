using System;

namespace Assets.Scripts.model.level.wave
{
    [Serializable]
    public class ZombieModel
    {
        // region: for XML parse
        public static readonly string TypeAttribute = "type";
        public static readonly string HealthAttribute = "health";
        public static readonly string SpeedAttribute = "speed";
        public static readonly string HitDamageAttribute = "hitDamage";
        public static readonly string HitDelayAttribute = "hitDelay";
        public static readonly string SpawndDelayAttribute = "spawnDelay";
        public static readonly string SpawndPositionAttribute = "spawnPosition";
        // end region: for XML parse

        public int Type;
        public float Health;
        public float Speed;
        public int HitDamage;
        public float HitDelay;
        public float SpawnDelay;
        public float SpawnPosition;
    }
}
