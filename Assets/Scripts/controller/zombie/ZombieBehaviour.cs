﻿using Assets.Scripts.model.level.wave;
using UnityEngine;

namespace Assets.Scripts.controller.zombie
{
    public class ZombieBehaviour : MonoBehaviour
    {
        private GameObject Target;

        private NavMeshAgent _navMeshAgent;
        private ZombieModel _model;

        public void SetZombieData(ZombieModel model)
        {
            _model = model;
            Target = GameObject.FindGameObjectWithTag("Gate");
            navMeshAgent.speed = model.Speed;
            MoveToTarget();

            transform.position = new Vector3(model.SpawnPosition, transform.position.y, transform.position.z);
        }


        public void MoveToTarget()
        {
            navMeshAgent.SetDestination(Target.transform.position);
        }

        public void Rest()
        {
            navMeshAgent.Stop();
        }

        private NavMeshAgent navMeshAgent
        {
            get { return _navMeshAgent ?? (_navMeshAgent = GetComponent<NavMeshAgent>()); }
        }
    }
}
