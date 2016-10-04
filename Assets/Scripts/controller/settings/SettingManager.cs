using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.controller.sound;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.model.level.wave;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.settings
{
    public class SettingManager : ISettingManager
    {
        private static readonly string StorageFileName = "";

        [Inject]
        IEventDispatcher eventDispatcher;

        private readonly Dictionary<string, SettingItem> _settingDictionary = new Dictionary<string, SettingItem>();
        private BinaryFormatter _formatter;


        public void Init()
        {
            InitSetting(SettingName.SoundVolume, typeof(int), 5);
            InitSetting(SettingName.MusicVolume, typeof(int), 12);
            InitSetting("Zombie", typeof(ZombieModel), new ZombieModel() { Health = 50, HitDamage = 10, HitDelay = 3, SpawnDelay = 2, SpawnPosition = 0, Speed = 5, Type = 1 });

            _formatter = new BinaryFormatter();

            SyncronizeWithPlayerPrefs();
        }

        private void SyncronizeWithPlayerPrefs()
        {
            foreach (var pair in _settingDictionary)
            {
                var name = pair.Key;
                var item = pair.Value;

                if (item.ValueType == typeof(int))
                {
                    if (PlayerPrefs.HasKey(name))
                    {
                        item.CurrentValue = PlayerPrefs.GetInt(name);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(name, (int)item.CurrentValue);
                    }
                }
                else if (item.ValueType == typeof(float))
                {
                    if (PlayerPrefs.HasKey(name))
                    {
                        item.CurrentValue = PlayerPrefs.GetFloat(name);
                    }
                    else
                    {
                        PlayerPrefs.SetFloat(name, (float)item.CurrentValue);
                    }
                }
                else if (item.ValueType == typeof(string))
                {
                    if (PlayerPrefs.HasKey(name))
                    {
                        item.CurrentValue = PlayerPrefs.GetString(name);
                    }
                    else
                    {
                        PlayerPrefs.SetString(name, (string)item.CurrentValue);
                    }
                }
                else
                {
                    if (PlayerPrefs.HasKey(name))
                    {
                        var base64 = PlayerPrefs.GetString(name);
                        var bytes = Convert.FromBase64String(base64);
                        using (var stream = new MemoryStream(bytes))
                        {
                            item.CurrentValue = _formatter.Deserialize(stream);
                        }
                        item.CurrentValue = Convert.ChangeType(item.CurrentValue, item.ValueType);
                    }
                    else
                    {
                        using (var stream = new MemoryStream())
                        {
                            _formatter.Serialize(stream, pair.Value.CurrentValue);
                            var bytes = stream.ToArray();
                            PlayerPrefs.SetString(pair.Key, Convert.ToBase64String(bytes));
                        }
                    }
                }
            }
            PlayerPrefs.Save();
        }

        private void InitSetting(string name, Type valueType, object defaultValue)
        {
            _settingDictionary.Add(name, new SettingItem()
            {
                ValueType = valueType,
                DefaultValue = defaultValue,
                CurrentValue = defaultValue
            });

            Debug.LogFormat("Setting {0} inited. Type: {1}", name, valueType);
        }

        public object GetSetting(string settingName)
        {
            SettingItem item;
            return _settingDictionary.TryGetValue(settingName, out item) ? item.CurrentValue : null;
        }

        public void SetSetting(string settingName, object settingValue)
        {
            SettingItem item;

            if (_settingDictionary.TryGetValue(settingName, out item))
            {
                if (item.CurrentValue != settingValue)
                {
                    item.CurrentValue = settingValue;
                }
            }
            else
            {
                Debug.LogErrorFormat("Setting [{0}] is not inited", settingName);
                throw new Exception("Wrong setting type");
            }
        }
    }
}
