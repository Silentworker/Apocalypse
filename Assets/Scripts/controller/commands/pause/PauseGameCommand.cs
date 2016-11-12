using Assets.Scripts.controller.headsup;
using Assets.Scripts.view.headsup;
using UnityEngine;
using Zenject;
using Command = Assets.Scripts.sw.core.command.Command;

namespace Assets.Scripts.controller.commands.pause
{
    public class PauseGameCommand : Command
    {
        [Inject]
        private IHeadsUpController headsUpController;

        public override void Execute(object data = null)
        {
            base.Execute();

            Time.timeScale = 0;

            headsUpController.HideMobileMenu();
            headsUpController.ShowPauseMenu();
        }
    }
}
