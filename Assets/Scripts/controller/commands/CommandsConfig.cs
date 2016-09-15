using Assets.Scripts.controller.commands.menu;
using Assets.Scripts.controller.commands.pause;
using Assets.Scripts.controller.events;
using Assets.Scripts.core.command.map;
using Assets.Scripts.core.config;
using Zenject;

namespace Assets.Scripts.controller.commands
{
    public class CommandsConfig : IConfig
    {
        [Inject]
        private ICommandsMap commandsMap;

        public void Init()
        {
            commandsMap.Map(GameEvent.InitMenu, typeof(InitMenuCommand));
            commandsMap.Map(GameEvent.StartGame, typeof(StartGameCommand));
            commandsMap.Map(GameEvent.PauseGame, typeof(PauseGameCommand));
            commandsMap.Map(GameEvent.ResumeGame, typeof(ResumeGameCommand));
        }
    }
}
