using Assets.Scripts.model.level.wave;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.zombie
{
    public class ZombieFactory : IZombieFactory
    {
        [Inject]
        private DiContainer container;

        public void Spawn(ZombieModel zombieModel)
        {
            var zombieObject = container.CreateAndParentPrefabResource("ZombieSimple", "ZombieFolder");
            zombieObject.SendMessage("SetZombieData", zombieModel);
        }
    }
}
