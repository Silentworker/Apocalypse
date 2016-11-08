using Assets.Scripts.controller.commands.game;
using Assets.Scripts.controller.events;
using Assets.Scripts.model.core.gate;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.command.map;
using Assets.Scripts.sw.core.eventdispatcher;
using Zenject;

namespace Assets.Scripts.model.level.executor
{
    public class LevelExecutor : ILevelExecutor
    {
        [Inject]
        private IEventDispatcher eventDispatcher;
        [Inject]
        private DiContainer container;

        [Inject] private ICommandsMap commandsMap;

        private WaveModel _currentWave;
        private LevelConfigModel _level;
        private IGateModel _gateModel;

        public void ExecuteLevel(LevelConfigModel level)
        {
            _level = level;
            
            eventDispatcher.AddEventListener(GameEvent.WaveComplete, startNextWave);
            startNextWave();
            _gateModel = container.Resolve<IGateModel>();
            _gateModel.Init(100);
        }

        private void startNextWave(object data = null)
        {
            if (_currentWave == null)
            {
                _currentWave = _level.Waves[0];
            }
            else
            {
                int currentWaveIndex = _level.Waves.IndexOf(_currentWave);

                if (++currentWaveIndex < (_level.Waves.Count))
                {
                    _currentWave = _level.Waves[currentWaveIndex];
                }
                else
                {
                    eventDispatcher.DispatchEvent(GameEvent.LevelComplete);
                    return;
                }
            }

            if (_currentWave == null) return;

            eventDispatcher.DispatchEvent(GameEvent.StartWave, _currentWave);
        }

        public void Clear()
        {

        }
    }
}
