using UnityEngine;
using UnityEngine.AI;
using TankBattle.StateMachine;
using TankBattle.Singleton;
using System;

namespace TankBattle.MVC.Enemy
{
    public class TankController
    {
        internal TankModel tankModel;
        internal EnemyTankView tankView;
        internal NavMeshHit closestHit;
        internal Vector3 center;
        internal NavMeshAgent agent;
        internal Transform target;
        internal bool bulletThrowen = true;

        public State CurrentState;
        public State Idle = new Idle();
        public State Patrol = new Patrol();
        public State Chase = new Chase();
        public State Attack = new Attack();

        public static event Action OnEnemyDeath;

        public TankController(TankModel tankModel, Vector3 position)
        {
            this.tankModel = tankModel;

            if (NavMesh.SamplePosition(position, out closestHit, 100f, 1))
            {
                center = closestHit.position;
                tankView = GameObjectPooler.Singleton.FetchFromPool(tankModel.Tag, closestHit.position, Quaternion.identity).GetComponent<EnemyTankView>();
            }

            this.tankModel.SetTankController(this);
            tankView.SetTankController(this);

            SetTankColor();

            CurrentState = Idle;
            CurrentState.OnEnter(this);
        }

        private void SetTankColor()
        {
            Renderer[] renderers = tankView.GetComponentsInChildren<Renderer>();
            for(int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.SetColor("_Color", tankModel.TankColor);
            }
        }

        internal void SetAgent(NavMeshAgent agent)
        {
            this.agent = agent;
        }

        internal void MinusHealth(int damage)
        {
            tankModel.Health -= damage;
            if (tankModel.Health <= 0)
            {
                tankView.gameObject.SetActive(false);
                OnEnemyDeath?.Invoke();
            }
        }

        public void ChangeState(State state)
        {
            CurrentState.OnExit(this);
            CurrentState = state;
            CurrentState.OnEnter(this);
        }
    }
}