using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.core.command
{
    interface ISequenceMacro
    {
        void Add(ICommand comand);

        void Remove(ICommand comand);

        void Cancel();
    }
}
