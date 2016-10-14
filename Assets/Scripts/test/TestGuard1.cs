using Assets.Scripts.sw.core.command.macro.mapper;

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
