using Assets.Scripts.controller.events;
using Assets.Scripts.model.level.wave;
using Assets.Scripts.sw.core.eventdispatcher;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.controller.zombie
{
    public class ZombieBehaviour : MonoBehaviour
    {
        public static int Number = 0;

        [Inject]
        private IEventDispatcher eventDispatcher;

        private GameObject _target;
        private NavMeshAgent _navMeshAgent;
        private ZombieModel _primeModel;
        private ZombieModel _model;

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "MachineGunBullet")
            {
                ApplyDamage(1f);
            }
        }

        void OnDestroy()
        {
            Debug.LogFormat("Number destroyed: {0}", ++Number);
        }

        public void SetZombieData(ZombieModel model)
        {
            _primeModel = model;
            _model = model.Clone();

            _target = GameObject.FindGameObjectWithTag("Gate");
            navMeshAgent.speed = model.Speed;
            MoveToTarget();

            transform.position = new Vector3(model.SpawnPosition, transform.position.y, transform.position.z);
        }

        public void MoveToTarget()
        {
            navMeshAgent.SetDestination(_target.transform.position);
        }

        public void Rest()
        {
            navMeshAgent.Stop();
        }

        private void ApplyDamage(float damage)
        {
            if (Dead) return;

            _model.Health -= damage;
            if (Dead)
            {
                eventDispatcher.DispatchEvent(GameEvent.ZombieKilled, _primeModel);
                Destroy(gameObject);
                return;
            }

            if (_model.Health < _primeModel.Health * .5f)
            {
                Speed = _primeModel.Speed * .5f;
            }
        }

        private float Speed
        {
            set
            {
                navMeshAgent.speed = value;
                _model.Speed = value;
            }
            get { return _model.Speed; }
        }

        private NavMeshAgent navMeshAgent
        {
            get { return _navMeshAgent ?? (_navMeshAgent = GetComponent<NavMeshAgent>()); }
        }

        private bool Dead
        {
            get { return _model.Health <= 0; }
        }
    }
}
