using System;

namespace Assets.Scripts.core.command.map
{
    public interface ICommandMap
    {
        void map(string eventType, Type commandType);
        void unMap(string eventType, Type commandType);
    }
}
