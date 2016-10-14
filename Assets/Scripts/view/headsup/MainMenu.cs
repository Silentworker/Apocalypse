using Assets.Scripts.controller.events;
using Assets.Scripts.sw.core.eventdispatcher;
using Assets.Scripts.sw.core.touch;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.view.headsup
{
    public class MainMenu : MonoBehaviour
    {
        [Inject]
        IEventDispatcher eventDispatcher;

        public GameObject MainMenuBgPrefab;
        public GameObject StartButtonPrefab;
        public GameObject SettingButtonPrefab;

        private GameObject _startButton;
        private GameObject _settingsButton;
        private GameObject _mainMenuBg;

        public void ShowMenu()
        {
            _mainMenuBg = Instantiate(MainMenuBgPrefab);
            _mainMenuBg.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);

            _startButton = Instantiate(StartButtonPrefab);
            _startButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _startButton.GetComponent<Toucher>().OnTouchDownHandler += StartGame;

            _settingsButton = Instantiate(SettingButtonPrefab);
            _settingsButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _settingsButton.GetComponent<Toucher>().OnTouchDownHandler += OpenSettingsView;

            Debug.Log("Show main menu");
        }

        public void HideMenu()
        {
            if (_startButton != null) _startButton.GetComponent<Toucher>().Clear();
            if (_settingsButton != null) _settingsButton.GetComponent<Toucher>().Clear();

            Destroy(_mainMenuBg);
            Destroy(_startButton);
            Destroy(_settingsButton);

            Debug.Log("Hide main menu");
        }

        private void StartGame()
        {
            eventDispatcher.DispatchEvent(GameEvent.StartGame);
        }

        public void OpenSettingsView()
        {
            Debug.Log("Open settings view...");
        }
    }
}
