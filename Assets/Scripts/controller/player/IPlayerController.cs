namespace Assets.Scripts.controller.player
{
    interface IPlayerController
    {
        void AllowPlayerControll();

        void ForbidPlayerControll();

        void TurnLeft();

        void TurnRight();

        void StopTurn();

        void FireMachineGun();

        void StopFireMachineGun();

        void FireCannon();
    }
}
