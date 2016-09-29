using Assets.Scripts.controller.events;
using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.core.model;
using Assets.Scripts.model.level;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.core
{
    public class ApplicationModel : Model
    {
        [Inject]
        ILevel level;

        private int _score;
        private int _gateHealth;
        private bool _gamePaused = false;

        public ApplicationModel(IEventDispatcher dispatcher, DiContainer container) : base(dispatcher, container)
        {
        }

        public void Init()
        {
            Debug.Log("Application model initiated");
            eventDispatcher.DispatchEvent(GameEvent.ShowMainMenu);

            eventDispatcher.DispatchEvent(GameEvent.Test);
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

        public void StartLevel()
        {
            level.Start();
        }
    }
}
