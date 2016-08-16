using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.core
{
    public class GameEvent : UnityEvent<Object>
    {
        public static readonly string INIT_MENU = "gameEvent_initMenu";
        public static readonly string START_GAME = "gameEvent_startGame";
    }
}
