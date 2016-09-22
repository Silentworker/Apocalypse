using System;
using System.Collections.Generic;
using Assets.Scripts.core.eventdispatcher;

namespace Assets.Scripts.core.settings
{
    public abstract class AbstractSettingManager : ISettingManager
    {
        private List<SettingConfig> _settings;
        protected IEventDispatcher eventDispatcher;

        protected AbstractSettingManager(IEventDispatcher ed)
        {
            eventDispatcher = ed;

            Init();
        }

        public virtual void Init()
        {

        }

        protected virtual void LoadSettings()
        {

        }

        protected void InitSetting(string name, Type type, string eventName, object defaultValue)
        {
            if (_settings == null) _settings = new List<SettingConfig>();

            _settings.Add(new SettingConfig() { Name = name, Type = type, EventName = eventName, DefaultValue = defaultValue });
        }

        public void SetSetting(string settingName, object value)
        {

        }

        public object GetSetting(string settingName)
        {
            return null;
        }
    }
}
