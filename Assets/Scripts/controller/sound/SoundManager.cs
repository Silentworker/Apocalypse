using Assets.Scripts.controller.events;
using Assets.Scripts.core.eventdispatcher;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.sound
{
    public class SoundManager : ISoundManager
    {
        [Inject]
        IEventDispatcher eventDispatcher;

        public void Init()
        {
            eventDispatcher.AddEventListener(SettingEvent.SoundVolumeChange, OnSoundVolumeChanged);
            eventDispatcher.AddEventListener(SettingEvent.MusicVolumeChange, OnMusicVolumeChanged);
        }

        private void OnSoundVolumeChanged(object data)
        {
            if (SoundVolume == (int)data) return;

            SoundVolume = (int)data;
            Debug.LogFormat("Sound volume changed to: {0}", SoundVolume);
        }

        private void OnMusicVolumeChanged(object data)
        {
            if (MusicVolume == (int)data) return;

            MusicVolume = (int)data;
            Debug.LogFormat("Music volume changed to: {0}", MusicVolume);
        }

        public int SoundVolume { get; private set; }
        public int MusicVolume { get; private set; }
    }
}
