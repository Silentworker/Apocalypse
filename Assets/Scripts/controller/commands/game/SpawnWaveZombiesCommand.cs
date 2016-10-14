using System.Runtime.InteropServices;
using Assets.Scripts.controller.events;
using Assets.Scripts.controller.zombie;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.command.async;
using Assets.Scripts.sw.core.eventdispatcher;
using Zenject;

namespace Assets.Scripts.controller.commands.game
{
    public class SpawnWaveZombiesCommand : AsyncCommand
    {
        [Inject]
        private IEventDispatcher eventDispatcher;
        [Inject]
        private IZombieFactory zombieFactory;

        private WaveModel _wave;
        private int _killedZombiesCount;
        public override void Execute(object data = null)
        {
            base.Execute();

            _wave = (WaveModel)data;
            if (_wave == null)
            {
                DispatchComplete(false);
                return;
            }

            eventDispatcher.AddEventListener(GameEvent.ZombieKilled, onZombieKilldedHandler);

            _killedZombiesCount = 0;

            if (_wave.Zombies != null && _wave.Zombies.Count > 0)
            {
                foreach (var zombie in _wave.Zombies)
                {
                    SpawnZombie(zombie);
                }
            }
            else
            {
                completeHandler();
            }
        }

        private void SpawnZombie(ZombieModel zombie)
        {
            zombieFactory.Spawn(zombie);
        }

        private void onZombieKilldedHandler(object data = null)
        {
            if (++_killedZombiesCount < _wave.Zombies.Count) return;

            completeHandler();
        }

        private void completeHandler()
        {
            eventDispatcher.RemoveEventListener(GameEvent.ZombieKilled, onZombieKilldedHandler);
            DispatchComplete(true);
        }
    }
}
