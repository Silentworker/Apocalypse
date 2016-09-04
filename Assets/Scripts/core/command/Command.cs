using System;
using Assets.Scripts.core.delegates;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command
{
    public class Command : ICommand
    {
        public Custom.VoidDelegate CancelParent;

        public virtual void Execute(Object data = null)
        {
            Debug.LogFormat("[{0}]: execute", GetType().Name);
        }
    }
}
