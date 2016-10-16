using System;
using Assets.Scripts.model.core;
using Assets.Scripts.sw.core.eventdispatcher;
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

        private MainMenu _mainMenu;
        private MobileMenu _mobileMenu;
        private PauseMenu _pauseMenu;
        private Prompts _prompts;

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
            mainMenu.ShowMenu();
        }

        public void HideMainMenu()
        {
            mainMenu.HideMenu();
        }

        public void ShowMobileMenu()
        {
            mobileMenu.ShowControlls();
        }

        public void HideMobileMenu()
        {
            mobileMenu.HideControlls();
        }

        public void ShowPauseMenu()
        {
            pauseMenu.ShowMenu();
        }

        public void HidePauseMenu()
        {
            pauseMenu.HideMenu();
        }

        public void ShowPrompt(string promo, float duration = float.NaN)
        {
            prompts.ShowPrompt(promo, duration);
        }

        private MainMenu mainMenu
        {
            get { return _mainMenu ?? (_mainMenu = GetComponent<MainMenu>()); }
        }

        private MobileMenu mobileMenu
        {
            get { return _mobileMenu ?? (_mobileMenu = GetComponent<MobileMenu>()); }
        }

        private PauseMenu pauseMenu
        {
            get { return _pauseMenu ?? (_pauseMenu = GetComponent<PauseMenu>()); }
        }

        private Prompts prompts
        {
            get { return _prompts ?? (_prompts = GetComponent<Prompts>()); }
        }

    }
}
