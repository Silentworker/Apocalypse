namespace Assets.Scripts.controller.sound
{
    public interface ISettingManager
    {
        void Init();

        object GetSetting(string settingName);

        void SetSetting(string settingName, object settingValue);
    }
}
