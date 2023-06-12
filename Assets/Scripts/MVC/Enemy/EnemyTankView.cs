﻿using UnityEngine;
using UnityEngine.AI;

namespace TankBattle.MVC.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour, IDamagable
    {
        private TankController tankController;
        [HideInInspector] public NavMeshAgent agent;

        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

        public void Update()
        {
            //tankController.Patrol();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") == true)
            {
                agent.isStopped = true;
                tankController.attackPlayer(other.gameObject.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                agent.isStopped = false;
            }
        }

        public void GetDamage(int damage)
        {
            tankController.MinusHealth(damage);
        }
    }
}