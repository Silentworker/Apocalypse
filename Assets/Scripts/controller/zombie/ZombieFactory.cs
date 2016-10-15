using System;
using System.Collections.Generic;
using Assets.Scripts.model.level.wave;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.zombie
{
    public class ZombieFactory : MonoBehaviour, IZombieFactory
    {
        [Inject]
        private DiContainer container;

        public GameObject ZombieSimplePrefab;

        private Dictionary<ZombieModel, float> _upcomingSpawn = new Dictionary<ZombieModel, float>();
        private List<ZombieModel> _spawned = new List<ZombieModel>();

        void Update()
        {
            foreach (var pair in _upcomingSpawn)
            {
                var zombie = pair.Key;
                var initialTime = pair.Value;

                if (Time.time > (initialTime + zombie.SpawnDelay))
                {
                    spawn(zombie);
                    _spawned.Add(zombie);
                }
            }

            foreach (var zombie in _spawned)
            {
                if (_upcomingSpawn.ContainsKey(zombie)) _upcomingSpawn.Remove(zombie);
            }

            _spawned.Clear();
        }

        public void AddSpawnable(ZombieModel zombieModel)
        {
            _upcomingSpawn.Add(zombieModel, Time.time);
        }

        private void spawn(ZombieModel zombie)
        {
            var zombieObject = container.InstantiatePrefab(ZombieSimplePrefab);
            zombieObject.transform.SetParent(gameObject.transform, false);

            var zombieBehaviour = zombieObject.GetComponent<ZombieBehaviour>();
            if (zombieBehaviour == null)
            {
                throw new Exception("Zombie prefab has no ZombieBehaviour component");
            }
            zombieBehaviour.SetZombieData(zombie);
        }
    }
}
