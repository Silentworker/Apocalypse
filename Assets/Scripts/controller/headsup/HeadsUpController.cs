using Assets.Scripts.controller.events;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.core.touch;
using Assets.Scripts.model.core;
using Assets.Scripts.view.mobile;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.controller.headsup
{
    public class HeadsUpController : MonoBehaviour, IHeadsUpController
    {
        [Inject]
        IEventDispatcher eventDispatcher;
        [Inject]
        ApplicationModel applicationModel;

        public GameObject StartButton;
        public GameObject SettingsButton;
        public GameObject MainMenuBg;
        public Text ScoreText;

        void Start()
        {
            ScoreText.text = "";

            Toucher startButtonLToucher = StartButton.GetComponent<Toucher>();
            startButtonLToucher.OnTouchDownHandler += StartGame;

            Toucher settingsButtonLToucher = SettingsButton.GetComponent<Toucher>();
            settingsButtonLToucher.OnTouchDownHandler += OpenSettingsView;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResumeOrPauseGame();
            }
        }

        private void ResumeOrPauseGame()
        {
            if (applicationModel.GamePause)
            {
                applicationModel.ResumeGame();
            }
            else
            {
                applicationModel.PauseGame();
            }
        }

        public void HideMainMenu()
        {
            Destroy(MainMenuBg);
            Destroy(StartButton);
            Destroy(SettingsButton);

            Debug.Log("Hide Menu");
        }

        public void StartGame()
        {
            eventDispatcher.DispatchEvent(GameEvent.StartGame);
        }

        public void OpenSettingsView()
        {
            Debug.Log("Open settings view...");
        }

        public void ShowMobileMenu()
        {
            GetComponent<MobileMenu>().ShowControlls();
        }
    }
}
