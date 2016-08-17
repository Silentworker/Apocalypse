using Assets.Scripts.controller.helper;
using Assets.Scripts.core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.controller
{
    public class HeadsUpController : MonoBehaviour
    {
        private static HeadsUpController _instance;

        public static HeadsUpController Instance
        {
            get { return _instance ?? (_instance = FindObjectOfType(typeof(HeadsUpController)) as HeadsUpController); }
        }

        public GameObject StartButton;
        public GameObject SettingsButton;
        public GameObject MainMenuBg;
        public Text ScoreText;

        void Start()
        {
            ScoreText.text = "";

            Clicker startButtonLClicker = StartButton.GetComponent<Clicker>();
            startButtonLClicker.OnClickHandler += StartGame;

            Clicker settingsButtonLClicker = SettingsButton.GetComponent<Clicker>();
            settingsButtonLClicker.OnClickHandler += OpenSettingsView;
        }

        public void HideMenu()
        {
            Destroy(MainMenuBg);
            Destroy(StartButton);
            Destroy(SettingsButton);

            Debug.Log("Hide Menu");
        }

        private void StartGame()
        {
            EventDispatcher.DispatchEvent(GameEvent.START_GAME);
        }

        private void OpenSettingsView()
        {
            Debug.Log("Open settings view...");
        }
    }
}
