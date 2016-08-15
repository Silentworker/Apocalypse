using Assets.Scripts.core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.controller
{
    public class HeadsUpController : MonoBehaviour
    {

        public GameObject StartButton;
        public GameObject SettingsButton;
        public GameObject MainMenuBg;
        public Text ScoreText;

        private static HeadsUpController _instance;

        public static HeadsUpController Instamce
        {
            get { return _instance ?? (_instance = FindObjectOfType(typeof(HeadsUpController)) as HeadsUpController); }
        }

        void Start()
        {
            ScoreText.text = "";

            Clicker startButtonLClicker = StartButton.GetComponent<Clicker>();
            startButtonLClicker.OnClickHandler += StartGame;

            Clicker settingsButtonLClicker = SettingsButton.GetComponent<Clicker>();
            settingsButtonLClicker.OnClickHandler += OpenSettingsView;
        }

        public void hideMenu()
        {
            Destroy(MainMenuBg);
            Destroy(StartButton);
            Destroy(SettingsButton);

            Debug.Log("HideMenu");
        }

        public static void HideMenu()
        {
            Instamce.hideMenu();
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
