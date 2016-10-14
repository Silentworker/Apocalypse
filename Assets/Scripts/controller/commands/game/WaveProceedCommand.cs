using Assets.Scripts.controller.events;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.command.macro;
using Assets.Scripts.sw.core.eventdispatcher;
using Zenject;
using ICommand = Assets.Scripts.sw.core.command.ICommand;

namespace Assets.Scripts.controller.commands.game

{
    public class WaveProceedCommand : SequenceMacro
    {
        [Inject]
        private IEventDispatcher eventDispatcher;

        private WaveModel _wave;
        private int _killedZombiesCount;

        public override void Prepare()
        {
            Add(typeof(WavePromoCommand));
            Add(typeof(SpawnWaveZombiesCommand));
            Add(typeof(WaveRewardCommand));
            CompleteHandler += onCompleteHandler;
        }

        public override void Execute(object data = null)
        {
            _wave = (WaveModel)data;
            base.Execute(_wave);
        }

        private void onCompleteHandler(ICommand command, bool success)
        {
            eventDispatcher.DispatchEvent(GameEvent.WaveComplete, _wave);
        }
    }
}
