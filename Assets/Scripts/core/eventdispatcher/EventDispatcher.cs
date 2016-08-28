using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.core.eventdispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly Dictionary<string, GameEvent> _eventDictionary = new Dictionary<string, GameEvent>();

        public void AddEventListener(string eventType, UnityAction<Object> eventHandler)
        {
            GameEvent gameEvent = null;
            if (_eventDictionary.TryGetValue(eventType, out gameEvent))
            {
                gameEvent.AddListener(eventHandler);
            }
            else
            {
                gameEvent = new GameEvent();
                gameEvent.AddListener(eventHandler);
                _eventDictionary.Add(eventType, gameEvent);
            }
        }

        public void RemoveEventListener(string eventType, UnityAction<Object> eventHandler)
        {
            GameEvent gameEvent = null;
            if (_eventDictionary.TryGetValue(eventType, out gameEvent))
            {
                gameEvent.RemoveListener(eventHandler);
            }
        }

        public void DispatchEvent(string eventName, Object data = null)
        {
            GameEvent gameEvent = null;
            if (_eventDictionary.TryGetValue(eventName, out gameEvent))
            {
                gameEvent.Invoke(data);
            }
        }
    }
}
