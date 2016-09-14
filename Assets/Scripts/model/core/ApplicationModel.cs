using Assets.Scripts.controller.events;
using Assets.Scripts.core;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.core.model;
using UnityEditor.Callbacks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.core
{
    public class ApplicationModel : Model
    {
        private int _score;
        private int _gateHealth;
        private bool _gamePause = false;

        public bool GamePause
        {
            get { return _gamePause; }
        }

        public void Init()
        {
            Debug.Log("Application model initiated");

            eventDispatcher.DispatchEvent(GameEvent.InitMenu);

            eventDispatcher.DispatchEvent(GameEvent.Test);
        }

        public void PauseGame()
        {
            if (_gamePause) return;

            _gamePause = true;
            eventDispatcher.DispatchEvent(GameEvent.PauseGame);
        }

        public void ResumeGame()
        {
            if (!_gamePause) return;

            _gamePause = false;
            eventDispatcher.DispatchEvent(GameEvent.ResumeGame);
        }


        public ApplicationModel(IEventDispatcher dispatcher, DiContainer dicontainer) : base(dispatcher, dicontainer)
        {

        }
    }
}
