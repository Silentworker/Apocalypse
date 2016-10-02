using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.model.core;
using Assets.Scripts.view.headsup;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.headsup
{
    public class HeadsUpController : MonoBehaviour, IHeadsUpController
    {
        [Inject]
        IEventDispatcher eventDispatcher;
        [Inject]
        ApplicationModel applicationModel;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeOrPauseGame();
            }
        }

        private void ResumeOrPauseGame()
        {
            if (applicationModel.GamePaused)
            {
                applicationModel.ResumeGame();
            }
            else
            {
                applicationModel.PauseGame();
            }
        }

        public void ShowMainMenu()
        {
            GetComponent<MainMenu>().ShowMenu();
        }

        public void HideMainMenu()
        {
            GetComponent<MainMenu>().HideMenu();
        }

        public void ShowMobileMenu()
        {
            GetComponent<MobileMenu>().ShowControlls();
        }

        public void HideMobileMenu()
        {
            GetComponent<MobileMenu>().HideControlls();
        }

        public void ShowPauseMenu()
        {
            GetComponent<PauseMenu>().ShowMenu();
        }

        public void HidePauseMenu()
        {
            GetComponent<PauseMenu>().HideMenu();
        }
    }
}
