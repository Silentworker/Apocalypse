using System;
using Assets.Scripts.core.eventdispatcher;
using Zenject;
using Object = UnityEngine.Object;

namespace Assets.Scripts.core.model
{
    public abstract class Model : Object
    {
        protected IEventDispatcher eventDispatcher;
        protected DiContainer container;

        protected Model(IEventDispatcher dispatcher, DiContainer dicontainer)
        {
            eventDispatcher = dispatcher;
            container = dicontainer;
        }
    }
}
