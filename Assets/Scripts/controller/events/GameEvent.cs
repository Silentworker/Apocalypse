using Assets.Scripts.core.events;

namespace Assets.Scripts.controller.events
{
    class GameEvent : BaseEvent
    {
        public static readonly string ShowMainMenu = "gameEvent_showMainMenu";
        public static readonly string StartGame = "gameEvent_startGame";
        public static readonly string PauseGame = "gameEvent_pauseGame";
        public static readonly string ResumeGame = "gameEvent_resumeGame";

        public static readonly string Test = "gameEvent_test";
    }
}
