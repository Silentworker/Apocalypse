using Assets.Scripts.controller.events;
using Assets.Scripts.controller.settings;
using Assets.Scripts.sw.core.eventdispatcher;
using Assets.Scripts.sw.core.settings;
using Assets.Scripts.sw.core.touch;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.view.headsup
{
    public class PauseMenu : MonoBehaviour
    {
        [Inject]
        IEventDispatcher eventDispatcher;
        [Inject]
        ISettingsManager _settingsManager;

        public GameObject PauseMenuBgPrefab;
        public GameObject ToMainMenuButtonPrefab;
        public GameObject MusicSliderPrefab;
        public GameObject SoundSliderPrefab;

        private GameObject _pauseMenuBg;
        private GameObject _toMainMenuButton;
        private GameObject _musicSlider;
        private GameObject _soundSlider;

        public void ShowMenu()
        {
            _pauseMenuBg = Instantiate(PauseMenuBgPrefab);
            _pauseMenuBg.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);

            _toMainMenuButton = Instantiate(ToMainMenuButtonPrefab);
            _toMainMenuButton.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _toMainMenuButton.GetComponent<Toucher>().OnTouchDownHandler += ToMainMenu;

            _musicSlider = Instantiate(MusicSliderPrefab);
            _musicSlider.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _musicSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { OnMusicSliderValueChanged(); });
            _musicSlider.GetComponent<Slider>().value = (int)_settingsManager.GetSetting(SettingName.MusicVolume);

            _soundSlider = Instantiate(SoundSliderPrefab);
            _soundSlider.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>(), false);
            _soundSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate { OnSoundSliderValueChanged(); });
            _soundSlider.GetComponent<Slider>().value = (int)_settingsManager.GetSetting(SettingName.SoundVolume);

            Debug.Log("Show pause menu");
        }

        public void HideMenu()
        {
            if (_toMainMenuButton != null) _toMainMenuButton.GetComponent<Toucher>().Clear();
            if (_soundSlider != null) _soundSlider.GetComponent<Slider>().onValueChanged.RemoveAllListeners();
            if (_musicSlider != null) _musicSlider.GetComponent<Slider>().onValueChanged.RemoveAllListeners();

            Destroy(_pauseMenuBg);
            Destroy(_toMainMenuButton);
            Destroy(_musicSlider);
            Destroy(_soundSlider);

            Debug.Log("Hide pause menu");
        }

        private void ToMainMenu()
        {
            HideMenu();
            eventDispatcher.DispatchEvent(GameEvent.ShowMainMenu);
        }

        private void OnMusicSliderValueChanged()
        {
            _settingsManager.SetSetting(SettingName.MusicVolume, (int)_musicSlider.GetComponent<Slider>().value);
        }

        private void OnSoundSliderValueChanged()
        {
            _settingsManager.SetSetting(SettingName.SoundVolume, (int)_soundSlider.GetComponent<Slider>().value);
        }
    }
}
