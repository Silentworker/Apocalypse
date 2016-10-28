using Assets.Scripts.controller.events;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.eventdispatcher;
using Zenject;

namespace Assets.Scripts.model.level.executor
{
    public class LevelExecutor : ILevelExecutor
    {
        [Inject]
        private IEventDispatcher eventDispatcher;

        private WaveModel _currentWave;
        private LevelConfigModel _level;

        public void ExecuteLevel(LevelConfigModel level)
        {
            _level = level;
            eventDispatcher.AddEventListener(GameEvent.WaveComplete, startNextWave);
            startNextWave();
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
