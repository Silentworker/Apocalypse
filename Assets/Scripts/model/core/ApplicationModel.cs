using Assets.Scripts.core;
using Assets.Scripts.core.eventdispatcher;
using UnityEditor.Callbacks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.core
{
    public class ApplicationModel
    {
        [Inject]
        IEventDispatcher eventDispatcher;

        private int _score;
        private int _gateHealth;

        public void Init()
        {
            Debug.Log("Application model initiated");
        }
    }
}
