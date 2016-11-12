using System;
using Assets.Scripts.controller.events;
using Assets.Scripts.sw.core.eventdispatcher;
using Assets.Scripts.sw.core.model;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.model.core.gate
{
    public class GateModel : IGateModel
    {
        [Inject]
        private IEventDispatcher eventDispatcher;

        private float _health;
        public void Init(float health)
        {
            _health = health;
            eventDispatcher.AddEventListener(GameEvent.GateDamage, ApplyDamage);
        }

        private void ApplyDamage(object data)
        {
            if (Destroyed) return;

            float damage = 0;
            try
            {
                damage = (float)data;
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("Gate damage data format error: {0}", e.Message);
            }

            _health -= damage;

            Debug.LogFormat("Heatlth: {0}  Damage: {1}", _health, damage);

            if (Destroyed)
            {
                eventDispatcher.DispatchEvent(GameEvent.GateDestroyed);
            }
        }

        private bool Destroyed { get { return _health <= 0; } }
    }
}
