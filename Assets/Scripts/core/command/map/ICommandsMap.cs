using System;
using Assets.Scripts.core.command.macro.mapper;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.map
{
    public interface ICommandsMap
    {
        ISubCommandMapper Map(string eventType, Type commandType);

        void UnMap(string eventType, Type commandType);

        void DirectCommand(Type commandType, object data = null);
    }
}
