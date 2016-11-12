using System;
using Assets.Scripts.consts;
using Assets.Scripts.controller.events;
using Assets.Scripts.controller.headsup;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.eventdispatcher;
using Assets.Scripts.view.headsup;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.zombie
{
    public class ZombieBehaviour : MonoBehaviour
    {
        [Inject]
        private IEventDispatcher eventDispatcher;
        [Inject]
        private IHeadsUpController headsUpController;

        private GameObject _target;
        private NavMeshAgent _navMeshAgent;
        private ZombieModel _primeModel; // Unchangable
        private ZombieModel _model;      // Changable
        private float _initialHitTime = float.NaN;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == Tag.MachineGunBullet)
            {
                TakeDamage(Damage.MachineGunBaseDamage);
            }
        }

        void Update()
        {
            var distance = Vector3.Distance(transform.position, Target.transform.position);

            if (distance < Distance.ZombieDamageDistance)
            {
                if (float.IsNaN(_initialHitTime))
                {
                    _initialHitTime = Time.time;
                }
                else
                {
                    if (Time.time >= _initialHitTime + _model.HitDelay)
                    {
                        HitTheGate();
                        _initialHitTime = float.NaN;
                    }
                }
            }
            else
            {
                _initialHitTime = float.NaN;
            }
        }

        private void HitTheGate()
        {
            eventDispatcher.DispatchEvent(GameEvent.GateDamage, _model.HitDamage);
        }

        void OnDestroy()
        {
            eventDispatcher.DispatchEvent(GameEvent.ZombieDestroyed, _primeModel);
        }

        public void SetZombieData(ZombieModel model)
        {
            _primeModel = model;
            _model = model.Clone();

            NavAgent.speed = model.Speed;
            MoveToTarget();

            transform.position = new Vector3(model.SpawnPosition, transform.position.y, transform.position.z);
        }

        private void MoveToTarget()
        {
            NavAgent.SetDestination(Target.transform.position);
        }

        public void Rest()
        {
            NavAgent.Stop();
        }

        private void TakeDamage(float damage)
        {
            if (Dead) return;

            _model.Health -= damage;

            if (Dead)
            {
                eventDispatcher.DispatchEvent(GameEvent.ZombieKilled, _primeModel);
                Destroy(gameObject);
                return;
            }

            if (_model.Health < _primeModel.Health * .3f)
            {
                Speed = _primeModel.Speed * .5f;
            }
        }

        private float Speed
        {
            set
            {
                NavAgent.speed = value;
                _model.Speed = value;
            }
            get { return _model.Speed; }
        }

        private NavMeshAgent NavAgent
        {
            get { return _navMeshAgent ?? (_navMeshAgent = GetComponent<NavMeshAgent>()); }
        }

        private GameObject Target
        {
            get { return _target ?? (_target = GameObject.FindGameObjectWithTag(Tag.Gate)); }
        }

        private bool Dead
        {
            get { return _model.Health <= 0; }
        }
    }
}
