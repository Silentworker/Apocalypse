using System;

namespace Assets.Scripts.model.level.wave
{
    [Serializable]
    public class ZombieModel
    {
        public int Form { get; set; }
        public float Health { get; set; }
        public float Speed { get; set; }
        public float HitDamage { get; set; }
        public float HitDelay { get; set; }
        public float SpawnDelay { get; set; }
        public float SpawnPosition { get; set; }

        public ZombieModel Clone()
        {
            return (ZombieModel)MemberwiseClone();
        }
    }
}
