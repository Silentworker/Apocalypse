using Assets.Scripts.core.delegates;

namespace Assets.Scripts.core.command
{
    public interface ISubCommand
    {
        CustomDelegate.Void CalcelParentCallback { get; set; }

        void CancelParent();
    }
}
