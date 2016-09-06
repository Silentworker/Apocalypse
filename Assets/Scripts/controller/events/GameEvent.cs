using Assets.Scripts.core.events;

namespace Assets.Scripts.controller.events
{
    class GameEvent : BaseEvent
    {
        public static readonly string InitMenu = "gameEvent_initMenu";

        public static readonly string StartGame = "gameEvent_startGame";

        public static readonly string TestAsyncCommand = "gameEvent_testAsyncCommand";
    }
}
