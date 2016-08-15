using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.core
{
    public class EventDispatcher
    {
        private readonly Dictionary<string, GameEvent> _eventDictionary = new Dictionary<string, GameEvent>();

        private static EventDispatcher _instance;

        private static EventDispatcher Instance
        {
            get { return _instance ?? (_instance = new EventDispatcher()); }
        }

        public static void AddEventListener(string eventType, UnityAction<Object> eventHandler)
        {
            GameEvent gameEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out gameEvent))
            {
                gameEvent.AddListener(eventHandler);
            }
            else
            {
                gameEvent = new GameEvent();
                gameEvent.AddListener(eventHandler);
                Instance._eventDictionary.Add(eventType, gameEvent);
            }
        }

        public static void RemoveEventListener(string eventType, UnityAction<Object> eventHandler)
        {
            GameEvent gameEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventType, out gameEvent))
            {
                gameEvent.RemoveListener(eventHandler);
            }
        }

        public static void DispatchEvent(string eventName, Object data = null)
        {
            GameEvent gameEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventName, out gameEvent))
            {
                gameEvent.Invoke(data);
            }
        }
    }
}
