using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.core.events;

namespace Assets.Scripts.controller.events
{
    public class SettingEvent : BaseEvent
    {
        public static readonly string SoundVolumeChange = "settingEvent_soundVolumeChange";
        public static readonly string MusicVolumeChange = "settingEvent_musicVolumeChange";
    }
}
