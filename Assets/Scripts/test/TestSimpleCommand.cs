using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.core.command;
using Object = UnityEngine.Object;

namespace Assets.Scripts.test
{
    public class TestSimpleCommand : Command
    {
        public override void Execute(Object data = null)
        {
            base.Execute();
        }
    }
}
