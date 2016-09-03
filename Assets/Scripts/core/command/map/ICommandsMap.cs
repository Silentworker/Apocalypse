using System;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.map
{
    public interface ICommandsMap
    {
        void Map(string eventType, Type commandType);

        void UnMap(string eventType, Type commandType);

        void DirectCommand(Type commandType, Object data);
    }
}
