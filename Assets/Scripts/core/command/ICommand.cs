using UnityEngine;

namespace Assets.Scripts.core.command
{
    public interface ICommand
    {
        void Execute(Object data = null);
    }
}
