using System;
using Assets.Scripts.core.delegates;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.macro.mapper
{
    public interface ISubCommandMapper
    {
        void Execute(Object data = null);

        ISubCommandMapper WithGuards(Type[] guardTypes);

        ISubCommandMapper WithData(Object data);

        Type CommandType { get; set; }

        CustomDelegate.BoolParameter CompleteCallBack { get; set; }

        CustomDelegate.Void CancelParentCallback { get; set; }
    }
}
