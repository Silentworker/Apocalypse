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
        [Inject]
        ILevelModel levelModel;

        private int _score;
        private int _gateHealth;

        public ApplicationModel(IEventDispatcher dispatcher, DiContainer container) : base(dispatcher, container)
        {
            GamePaused = false;
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
            levelModel.Start();
        }

        public bool GamePaused { get; private set; }
    }
}
