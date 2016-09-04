using System;
using Assets.Scripts.core.command.macro;
using Assets.Scripts.core.command.macro.mapper;
using Object = UnityEngine.Object;

namespace Assets.Scripts.test
{
    public class TestMacro : SequenceMacro
    {
        public override void Execute(Object data = null)
        {
            base.Execute();
        }

        public override void Prepare()
        {
            Add(typeof(TestAsyncCommand)).WithGuards(new Type[] { typeof(TestGuard1) });
            Add(typeof(TestAsyncCommand2));
            Add(typeof(TestSimpleCommand));
        }
    }
}
