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

        private List<GameObject> _zombies = new List<GameObject>();
        private List<Tween> _spawnTweens = new List<Tween>();

        public void AddSpawnable(ZombieModel zombie)
        {
            _spawnTweens.Add(DOVirtual.DelayedCall(zombie.SpawnDelay, () => { Spawn(zombie); }, false));
        }

        public void ClearSpawns()
        {
            foreach (var tween in _spawnTweens)
            {
                tween.Kill();
            }
        }

        public void Clear()
        {
            ClearSpawns();
        }

        private void Spawn(ZombieModel zombie)
        {
            var zombieObject = container.InstantiatePrefab(ZombieSimplePrefab);
            zombieObject.transform.SetParent(gameObject.transform, false);
            _zombies.Add(zombieObject);

            var zombieBehaviour = zombieObject.GetComponent<ZombieBehaviour>();
            if (zombieBehaviour == null)
            {
                throw new Exception("Zombie prefab has no ZombieBehaviour component");
            }
            zombieBehaviour.SetZombieData(zombie);
        }
    }
}