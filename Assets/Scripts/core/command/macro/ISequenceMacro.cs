using System;
using Assets.Scripts.core.command.macro.mapper;

namespace Assets.Scripts.core.command.macro
{
    interface ISequenceMacro
    {
        ISubCommandMapper Add(Type comandType);

        void Remove(Type comandType);

        void Prepare();

        void Cancel();
    }
}
