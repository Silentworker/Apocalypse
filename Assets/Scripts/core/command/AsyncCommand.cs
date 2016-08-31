using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command
{
    public class AsyncCommand : Command
    {
        public delegate void CompleteHandlerDelegate(bool sucess);

        public CompleteHandlerDelegate CompleteHandler;

        public override void Execute(Object data = null)
        {
            base.Execute();
        }

        protected void DispatchComplete(bool sucess)
        {
            if (CompleteHandler != null) CompleteHandler(sucess);
        }
    }
}
