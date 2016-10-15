using Assets.Scripts.controller.camera;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.controller.player;
using Assets.Scripts.model.core;
using Zenject;
using Command = Assets.Scripts.sw.core.command.Command;

namespace Assets.Scripts.controller.commands
{
    public class StartGameCommand : Command
    {
        [Inject]
        private ICameraController cameraController;
        [Inject]
        private IHeadsUpController headsUpController;
        [Inject]
        private IPlayerController playerController;
        [Inject]
        private ApplicationModel applicationModel;

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