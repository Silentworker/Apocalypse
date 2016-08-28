using Assets.Scripts.controller;
using Assets.Scripts.controller.commands;
using Assets.Scripts.core;
using Assets.Scripts.core.command;
using Assets.Scripts.core.config;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class ApplicationInit : MonoBehaviour
    {
        [Inject]
        private IEventDispatcher eventDispatcher;
        [Inject]
        private IConfig commandsConfig;

        private CommandsConfig _commandConfig;

        void Awake()
        {
            Application.targetFrameRate = 60;

            commandsConfig.Init();

            eventDispatcher.DispatchEvent(GameEvent.INIT_MENU);
        }
    }
}
