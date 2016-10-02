using Assets.Scripts.controller.events;
using Assets.Scripts.core.command.async;
using Assets.Scripts.core.eventdispatcher;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.test
{
    public class TestAsyncCommand2 : AsyncCommand
    {
        [Inject]
        IEventDispatcher eventDispatcher;

        public override void Execute(object data = null)
        {
            eventDispatcher.AddEventListener(GameEvent.StartGame, OnStartGame);
            base.Execute();
        }

        void OnStartGame(object data = null)
        {
            eventDispatcher.RemoveEventListener(GameEvent.StartGame, OnStartGame);
            DispatchComplete(false);
        }
    }
}
