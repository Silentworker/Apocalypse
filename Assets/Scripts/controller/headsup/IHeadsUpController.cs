namespace Assets.Scripts.controller.headsup
{
    public interface IHeadsUpController
    {
        void ShowMainMenu();

        void HideMainMenu();

        void ShowMobileMenu();

        void HideMobileMenu();

        void ShowPauseMenu();

        void HidePauseMenu();

        void ShowPrompt(string promo);
    }
}
