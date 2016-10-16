using System;
using System.Collections.Generic;
using Assets.Scripts.model.level.wave;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.zombie
{
    public class ZombieFactory : MonoBehaviour, IZombieFactory
    {
        [Inject]
        private DiContainer container;

        public GameObject ZombieSimplePrefab;

        public void AddSpawnable(ZombieModel zombieModel)
        {
            DOVirtual.DelayedCall(zombieModel.SpawnDelay, () => { spawn(zombieModel); });
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
