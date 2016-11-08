using Assets.Scripts.sw.core.command.async;
using Assets.Scripts.view.headsup;
using Zenject;

namespace Assets.Scripts.controller.commands.game
{
    public class GateDestroyedCommand : AsyncCommand
    {
        [Inject] private IHeadsUpController headsUpController;

        public override void Execute(object data = null)
        {
            base.Execute();

            headsUpController.ShowPrompt("Ворота разрушены.\n Поражен твоей неудачей!", 10);
            DispatchComplete(true);
        }
    }
}