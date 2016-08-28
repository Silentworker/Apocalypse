using System;

namespace Assets.Scripts.core.command.map
{
    public interface ICommandsMap
    {
        void Map(string eventType, Type commandType);

        void UnMap(string eventType, Type commandType);
    }
}
