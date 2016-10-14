using Assets.Scripts.sw.core.settings;

namespace Assets.Scripts.controller.settings
{
    public class SettingsManager : AnstractSettingsManager
    {
        public override void Prepare()
        {
            InitSetting(SettingName.SoundVolume, typeof(int), 10);
            InitSetting(SettingName.MusicVolume, typeof(int), 10);
        }
    }
}
