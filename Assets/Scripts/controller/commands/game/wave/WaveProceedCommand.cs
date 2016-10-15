using Assets.Scripts.controller.events;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.command.macro;
using Assets.Scripts.sw.core.eventdispatcher;
using Zenject;
using ICommand = Assets.Scripts.sw.core.command.ICommand;

namespace Assets.Scripts.controller.commands.game.wave
{
    public class WaveProceedCommand : SequenceMacro
    {
        [Inject]
        private IEventDispatcher eventDispatcher;

        private WaveModel _wave;

        public override void Prepare()
        {
            Add(typeof(WavePromoCommand)).WithData(_wave);
            Add(typeof(WaveZombiesLifeTimeCommand)).WithData(_wave);
            Add(typeof(WaveRewardCommand)).WithData(_wave);
            CompleteHandler += onCompleteHandler;
        }

        public override void Execute(object data = null)
        {
            _wave = (WaveModel)data;
            base.Execute();
        }

        private void onCompleteHandler(ICommand command, bool success)
        {
            eventDispatcher.DispatchEvent(GameEvent.WaveComplete, _wave);
            _wave = null;
        }
    }
}
