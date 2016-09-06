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

        public override void Execute(Object data = null)
        {
            eventDispatcher.AddEventListener(GameEvent.StartGame, OnStartGame);
            base.Execute();
        }

        void OnStartGame(Object data = null)
        {
            eventDispatcher.RemoveEventListener(GameEvent.StartGame, OnStartGame);
            DispatchComplete(true);
        }
    }
}
