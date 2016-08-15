using Assets.Scripts.core.command;
using UnityEngine;

namespace Assets.Scripts.controller.commands
{
    public class StartGameCommand : Command {
        public override void Execute(Object data = null)
        {
            base.Execute();

            HeadsUpController.HideMenu();
            CameraController.FollowPlayer();
        }
    }
}
