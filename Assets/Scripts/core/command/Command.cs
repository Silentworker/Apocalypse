using System;
using Assets.Scripts.core.delegates;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command
{
    public abstract class Command : ICommand, ISubCommand
    {
        public virtual void Execute(Object data = null)
        {
            Debug.LogFormat("[{0}][{1}]: execute", Math.Ceiling(Time.time * 1000), GetType().Name);
        }

        public void CancelParent()
        {
            if (CalcelParentCallback != null) CalcelParentCallback();
        }

        public CustomDelegate.Void CalcelParentCallback { get; set; }
    }
}
