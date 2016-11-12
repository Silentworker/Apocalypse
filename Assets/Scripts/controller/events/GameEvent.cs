using Assets.Scripts.sw.core.events;

namespace Assets.Scripts.controller.events
{
    public class GameEvent : BaseEvent
    {
        public static readonly string ShowMainMenu = "gameEvent_showMainMenu";
        public static readonly string StartGame = "gameEvent_startGame";
        public static readonly string PauseGame = "gameEvent_pauseGame";
        public static readonly string ResumeGame = "gameEvent_resumeGame";

        public static readonly string StartLevel = "gameEvent_startLevel";
        public static readonly string StartWave = "gameEvent_startWave";
        public static readonly string WaveComplete = "gameEvent_waveComplete";
        public static readonly string LevelComplete = "gameEvent_levelComplete";

        public static readonly string ZombieDamage = "gameEvent_zombieDamage";
        public static readonly string ZombieKilled = "gameEvent_zombieKilled";
        public static readonly string ZombieDestroyed = "gameEvent_zombieDestroyed";

        public static readonly string GateDamage = "gameEvent_gateDamage";
        public static readonly string GateDestroyed = "gameEvent_gateDestroyed";

        public static readonly string Test = "gameEvent_test";
    }
}