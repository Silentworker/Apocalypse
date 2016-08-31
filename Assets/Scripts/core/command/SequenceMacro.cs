using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.command
{
    public class SequenceMacro : AsyncCommand, ISequenceMacro
    {
        private List<ICommand> _commands;

        public override void Execute(Object data = null)
        {
            base.Execute();
        }

        public void Add(ICommand comand)
        {
        }

        public void Remove(ICommand comand)
        {
        }

        public void Cancel()
        {
        }
    }
}
