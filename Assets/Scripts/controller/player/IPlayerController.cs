namespace Assets.Scripts.controller.player
{
    public interface IPlayerController
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
