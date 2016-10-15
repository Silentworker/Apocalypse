using Assets.Scripts.model.level.wave;

namespace Assets.Scripts.controller.zombie
{
    public interface IZombieFactory
    {
        void AddSpawnable(ZombieModel zombieModel);
    }
}
