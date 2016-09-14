using Assets.Scripts.core.eventdispatcher;
using Assets.Scripts.core.model;
using Zenject;

namespace Assets.Scripts.model.level
{
    class LevelModel : Model
    {
        public LevelModel(IEventDispatcher dispatcher, DiContainer dicontainer) : base(dispatcher, dicontainer)
        {
        }
    }
}
