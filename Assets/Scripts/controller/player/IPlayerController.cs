namespace Assets.Scripts.controller.player
{
    interface IPlayerController
    {
        void AllowControlls();

        void ForbidControlls();

        void TurnLeft();

        void TurnRight();

        void StopTurn();

        void FireMachineGun();

        void StopFireMachineGun();

        void FireCannon();
    }
}
