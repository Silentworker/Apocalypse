using Assets.Scripts.core.delegates;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command.async
{
    public class AsyncCommand : Command
    {
        public Custom.CommandCompeteDeletage CompleteHandler;

        public override void Execute(Object data = null)
        {
            base.Execute();
        }

        protected void DispatchComplete(bool suсcess)
        {
            Debug.LogFormat("[{0}]: complete. Success: {1}", GetType().Name, suсcess);
            if (CompleteHandler != null) CompleteHandler(this);
        }
    }
}
