using Assets.Scripts.controller.events;
using Assets.Scripts.model.level;
using Assets.Scripts.sw.core.eventdispatcher;
using Assets.Scripts.sw.core.model;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.core
{
    public class ApplicationModel : Model
    {
        private int _score;
        private int _gateHealth;
        private ILevelModel _levelModel;

        public ApplicationModel(IEventDispatcher dispatcher, DiContainer container) : base(dispatcher, container)
        {
            GamePaused = false;

            _levelModel = container.Resolve<ILevelModel>();
        }

        public void Init()
        {
            Debug.Log("Application model initiated");

            eventDispatcher.DispatchEvent(GameEvent.ShowMainMenu);
        }

        public void PauseGame()
        {
            if (GamePaused) return;

            GamePaused = true;
            eventDispatcher.DispatchEvent(GameEvent.PauseGame);
        }

        public void ResumeGame()
        {
            if (!GamePaused) return;

            GamePaused = false;
            eventDispatcher.DispatchEvent(GameEvent.ResumeGame);
        }

        public void StartLevel()
        {
            _levelModel.Start();
        }

        public bool GamePaused { get; private set; }
    }
}
