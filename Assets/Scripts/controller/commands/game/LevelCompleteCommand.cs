using Assets.Scripts.controller.headsup;
using Assets.Scripts.model.core;
using Assets.Scripts.sw.core.command.async;
using Assets.Scripts.view.headsup;
using DG.Tweening;
using Zenject;

namespace Assets.Scripts.controller.commands.game
{
    public class LevelCompleteCommand : AsyncCommand
    {
        [Inject]
        private IHeadsUpController headsUpController;
        [Inject]
        private ApplicationModel applicationModel;

        public override void Execute(object data = null)
        {
            const float promoDuration = 5f;
            headsUpController.ShowPrompt("Уровень пройден!", promoDuration);
            DOVirtual.DelayedCall(promoDuration, dellayedComplete);
        }

        private void dellayedComplete()
        {
            DispatchComplete(true);
        }
    }
}
