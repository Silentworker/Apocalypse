using Assets.Scripts.controller;
using Assets.Scripts.controller.commands;
using Assets.Scripts.core;
using Assets.Scripts.core.command;
using Assets.Scripts.core.config;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.model.core;
using Assets.Scripts.models;
using UnityEngine;
using Zenject;

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


        private CommandsConfig _commandConfig;

        void Awake()
        {
            Application.targetFrameRate = 60;

            commandsConfig.Init();

            applicationModel.Init();

            eventDispatcher.DispatchEvent(GameEvent.INIT_MENU);


        }
    }
}
