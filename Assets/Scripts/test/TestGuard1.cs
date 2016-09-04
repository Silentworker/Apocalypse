using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.core.command.macro.mapper;

namespace Assets.Scripts.test
{
    public class TestGuard1 : IGuard
    {
        public bool Let()
        {
            return true;
        }
    }
}
