using Assets.Scripts.controller.camera;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.models;
using UnityEngine;
using Zenject;
using Command = Assets.Scripts.core.command.Command;

namespace Assets.Scripts.controller.commands
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
