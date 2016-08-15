using System;

namespace Assets.Scripts.core.command.map
{
    public interface ICommandMap
    {
        void MapEventToCommand(string eventType, Type commandType);
        void UnMapEventToCommand(string eventType, Type commandType);
    }
}
