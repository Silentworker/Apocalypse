using System.Timers;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.command.async;
using ModestTree;
using Zenject;

namespace Assets.Scripts.controller.commands.game.wave
{
    public class WaveRewardCommand : AsyncCommand
    {
        [Inject]
        private IHeadsUpController headsUpController;

        private WaveModel _wave;
        private Timer _timer;
        public override void Execute(object data = null)
        {
            base.Execute();

            _wave = (WaveModel)data;

            headsUpController.ShowPrompt("Волна {0} окончена. Награда {1} очков".Fmt(_wave.Id, _wave.Award.Score));

            DispatchComplete(true);
            _wave = null;
        }
    }
}
