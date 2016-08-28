using Assets.Scripts.core;
using Assets.Scripts.core.command.map;
using Assets.Scripts.core.config;
using Zenject;

namespace Assets.Scripts.controller.commands
{
    public class CommandsConfig : IConfig
    {
        [Inject]
        private ICommandsMap _commandsMap;

        public void Init()
        {
            _commandsMap.Map(GameEvent.INIT_MENU, typeof(InitMenuCommand));
            _commandsMap.Map(GameEvent.START_GAME, typeof(StartGameCommand));
        }
    }
}
