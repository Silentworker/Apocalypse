using Assets.Scripts.controller.camera;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.controller.player;
using UnityEngine;
using Zenject;
using Command = Assets.Scripts.core.command.Command;

namespace Assets.Scripts.controller.commands
{
    public class StartGameCommand : Command
    {
        [Inject]
        ICameraController cameraController;
        [Inject]
        IHeadsUpController headsUpController;
        [Inject]
        IPlayerController playerController;

        public override void Execute(Object data = null)
        {
            headsUpController.HideMainMenu();
            headsUpController.ShowMobileMenu();
            playerController.AllowControlls();
            cameraController.FollowPlayer();

            base.Execute();
        }
    }
}
