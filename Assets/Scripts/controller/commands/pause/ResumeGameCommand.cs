using Assets.Scripts.controller.headsup;
using UnityEngine;
using Zenject;
using Command = Assets.Scripts.sw.core.command.Command;

namespace Assets.Scripts.controller.commands.pause
{
    public class ResumeGameCommand : Command
    {
        [Inject]
        IHeadsUpController headsUpController;

        public override void Execute(object data = null)
        {
            base.Execute();

            Time.timeScale = 1;

            headsUpController.HidePauseMenu();
            headsUpController.ShowMobileMenu();
        }
    }
}
