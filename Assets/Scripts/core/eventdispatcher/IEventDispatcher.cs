using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.core.eventdispatcher
{
    public interface IEventDispatcher
    {
        void AddEventListener(string eventType, UnityAction<Object> eventHandler);
        void RemoveEventListener(string eventType, UnityAction<Object> eventHandler);
        void DispatchEvent(string eventName, Object data = null);
    }
}
