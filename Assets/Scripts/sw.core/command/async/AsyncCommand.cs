using Assets.Scripts.sw.core.delegates;
using UnityEngine;

namespace Assets.Scripts.sw.core.command.async
{
    public abstract class AsyncCommand : Command
    {
        public CustomDelegate.CommandCompete CompleteHandler;

        public override void Execute(object data = null)
        {
            base.Execute();
        }

        protected void DispatchComplete(bool suсcess)
        {
            Debug.LogFormat("[{0}]: complete. Success: {1}", GetType().Name, suсcess);
            if (CompleteHandler != null) CompleteHandler(this, suсcess);
        }
    }
}
