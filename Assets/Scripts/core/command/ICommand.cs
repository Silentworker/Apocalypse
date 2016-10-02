using UnityEngine;

namespace Assets.Scripts.core.command
{
    public interface ICommand
    {
        void Execute(object data = null);
    }
}
