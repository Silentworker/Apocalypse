using Assets.Scripts.controller.camera;
using Assets.Scripts.controller.headsup;
using UnityEngine;
using Zenject;
using Command = Assets.Scripts.core.command.Command;

namespace Assets.Scripts.controller.commands.menu
{
    public class ShowMainMenuCommand : Command
    {
        [Inject]
        private ICameraController cameraController;
        [Inject]
        private IHeadsUpController heasUpController;

        public override void Execute(Object data = null)
        {
            base.Execute();

            cameraController.MoveToMenuPosition();

            heasUpController.ShowMainMenu();
        }
    }
}
