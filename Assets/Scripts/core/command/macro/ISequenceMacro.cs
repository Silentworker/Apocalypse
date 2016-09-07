using System;
using Assets.Scripts.core.command.macro.mapper;

namespace Assets.Scripts.core.command.macro
{
    interface ISequenceMacro : IMacro
    {
        ISubCommandMapper Add(Type comandType);

        void Remove(Type comandType);

        void Cancel();
    }
}
