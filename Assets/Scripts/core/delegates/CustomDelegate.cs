using Assets.Scripts.core.command;
using UnityEngine;

namespace Assets.Scripts.core.delegates
{
    public class CustomDelegate
    {
        public delegate void Void();
        public delegate void BoolParameter(bool check);
        public delegate void CommandCompete(ICommand command, bool success);
    }
}
