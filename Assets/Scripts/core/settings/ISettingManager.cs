﻿namespace Assets.Scripts.core.settings
{
    public interface ISettingManager
    {
        void Init();

        void SetSetting(string settingName, object value);

        object GetSetting(string settingName);
    }
}
