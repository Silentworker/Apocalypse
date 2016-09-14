using Assets.Scripts.controller.camera;
using UnityEngine;
using Zenject;
using Command = Assets.Scripts.core.command.Command;

namespace Assets.Scripts.controller.commands.menu
{
    public class InitMenuCommand : Command
    {
        [Inject]
        private ICameraController cameraController;

        public override void Execute(Object data = null)
        {
            base.Execute();

            cameraController.MoveToMenuPosition();
        }
    }
}
