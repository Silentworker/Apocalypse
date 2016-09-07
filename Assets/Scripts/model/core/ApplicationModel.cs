using Assets.Scripts.controller.events;
using Assets.Scripts.core;
using Assets.Scripts.core.eventdispatcher;
using UnityEditor.Callbacks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.core
{
    public class ApplicationModel
    {
        [Inject]
        IEventDispatcher eventDispatcher;

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

    }
}
