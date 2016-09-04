using System;
using Assets.Scripts.core.delegates;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.macro.mapper
{
    public interface ISubCommandMapper
    {
        Type CommandType { get; set; }

        ISubCommandMapper WithGuards(Type[] guardTypes);

        ISubCommandMapper WithData(Object data);

        Custom.VoidDelegate CompleteCallBack { get; set; }

        void Execute(Object data = null);
    }
}
