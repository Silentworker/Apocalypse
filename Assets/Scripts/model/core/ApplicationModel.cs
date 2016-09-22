using System;
using Assets.Scripts.controller.commands.menu;
using Assets.Scripts.controller.events;
using Assets.Scripts.core;
using Assets.Scripts.core.command.map;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.core.model;
using UnityEditor.Callbacks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.core
{
    public class ApplicationModel : Model
    {
        [Inject]
        ICommandsMap commandMap;

        private int _score;
        private int _gateHealth;
        private bool _gamePaused = false;

        public ApplicationModel(IEventDispatcher dispatcher, DiContainer dicontainer) : base(dispatcher, dicontainer)
        {

        }

        public void Init()
        {
            Debug.Log("Application model initiated");

            //eventDispatcher.DispatchEvent(GameEvent.ShowMainMenu);
            commandMap.DirectCommand(typeof(ShowMainMenuCommand));
        }

        public void PauseGame()
        {
            if (_gamePaused) return;

            _gamePaused = true;
            eventDispatcher.DispatchEvent(GameEvent.PauseGame);
        }

        public void ResumeGame()
        {
            if (!_gamePaused) return;

            _gamePaused = false;
            eventDispatcher.DispatchEvent(GameEvent.ResumeGame);
        }

        public bool GamePaused
        {
            get { return _gamePaused; }
        }
    }
}
