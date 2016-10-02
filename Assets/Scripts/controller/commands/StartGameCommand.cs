using Assets.Scripts.controller.camera;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.controller.player;
using Assets.Scripts.model.core;
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
        [Inject]
        ApplicationModel applicationModel;

        public override void Execute(object data = null)
        {
            base.Execute();

            headsUpController.HideMainMenu();
            headsUpController.ShowMobileMenu();

            playerController.AllowPlayerControll();

            cameraController.FollowPlayer();

            applicationModel.StartLevel();
        }
    }
}
