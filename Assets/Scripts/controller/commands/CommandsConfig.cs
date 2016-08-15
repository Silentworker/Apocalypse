using Assets.Scripts.core;
using Assets.Scripts.core.command.map;
using Assets.Scripts.core.config;

namespace Assets.Scripts.controller.commands
{
    public class CommandsConfig : IConfig
    {
        public void Init()
        {
            CommandMap.Map(GameEvent.START_GAME, typeof(StartGameCommand));
        }
    }
}
