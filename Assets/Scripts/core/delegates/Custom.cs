using Assets.Scripts.core.command;
using UnityEngine;

namespace Assets.Scripts.core.delegates
{
    public class Custom
    {
        public delegate void VoidDelegate();
        public delegate void CommandCompeteDeletage(ICommand command);
    }
}
