using Assets.Scripts.controller.events;
using Assets.Scripts.core;
using Assets.Scripts.core.command.map;
using Assets.Scripts.core.config;
using Assets.Scripts.core.events;
using Assets.Scripts.test;
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
            //commandsMap.Map(GameEvent.StartGame, typeof(StartGameCommand));
            commandsMap.Map(GameEvent.TestAsyncCommand, typeof(TestMacro));
        }
    }
}
