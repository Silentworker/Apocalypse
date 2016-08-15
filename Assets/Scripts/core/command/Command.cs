using UnityEngine;

namespace Assets.Scripts.core.command
{
    public abstract class Command : Object, ICommand
    {
        public virtual void Execute(Object data = null)
        {
            Debug.LogFormat("[{0}]: execute", GetType().Name);
        }
    }
}
