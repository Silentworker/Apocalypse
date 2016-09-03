using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.core
{
    public class GameEvent : UnityEvent<Object>
    {
        public static readonly string InitMenu = "gameEvent_initMenu";

        public static readonly string StartGame = "gameEvent_startGame";
    }
}
