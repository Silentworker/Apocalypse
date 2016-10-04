using Assets.Scripts.controller.sound;
using Assets.Scripts.core.config;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.model.core;
using UnityEngine;
using Zenject;
using ISettingManager = Assets.Scripts.controller.sound.ISettingManager;

namespace Assets.Scripts
{
    public class ApplicationInit : MonoBehaviour
    {
        [Inject]
        IEventDispatcher eventDispatcher;
        [Inject]
        IConfig commandsConfig;
        [Inject]
        ApplicationModel applicationModel;
        [Inject]
        ISettingManager settingManager;

        void Awake()
        {
            Application.targetFrameRate = 60;

            commandsConfig.Init();

            applicationModel.Init();

            settingManager.Init();
        }
    }
}
