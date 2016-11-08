using Assets.Scripts.controller.commands.game;
using Assets.Scripts.controller.commands.game.wave;
using Assets.Scripts.controller.commands.menu;
using Assets.Scripts.controller.commands.pause;
using Assets.Scripts.controller.events;
using Assets.Scripts.sw.core.command.map;
using Assets.Scripts.sw.core.config;
using Zenject;

namespace Assets.Scripts.controller.commands
{
    public class CommandsConfig : IConfig
    {
        [Inject]
        private ICommandsMap commandsMap;

        public void Init()
        {
            commandsMap.Map(GameEvent.ShowMainMenu, typeof(ShowMainMenuCommand));
            commandsMap.Map(GameEvent.StartGame, typeof(StartGameCommand));
            commandsMap.Map(GameEvent.PauseGame, typeof(PauseGameCommand));
            commandsMap.Map(GameEvent.ResumeGame, typeof(ResumeGameCommand));
            commandsMap.Map(GameEvent.StartWave, typeof(WaveProceedCommand));
            commandsMap.Map(GameEvent.LevelComplete, typeof(LevelCompleteCommand));
            commandsMap.Map(GameEvent.GateDestroyed, typeof(GateDestroyedCommand));

            //commandsMap.Map(GameEvent.Test, typeof(TestMacro1));
        }
    }
}
