using UnityEngine;
using UnityEngine.AI;
using TankBattle.StateMachine;
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
        // State Machine
        public State CurrentState;
        public State Idle = new Idle();
        public State Patrol = new Patrol();
        public State Chase = new Chase();
        public State Attack = new Attack();

        public static event Action OnEnemyDeath;

        public TankController(TankModel tankModel, EnemyTankView tankView, Vector3 position)
        {
            this.tankModel = tankModel;

            if (NavMesh.SamplePosition(position, out closestHit, 100f, 1))
            {
                position = center = closestHit.position;
                this.tankView = GameObject.Instantiate<EnemyTankView>(tankView, position, Quaternion.identity);
            }

            this.tankModel.setTankController(this);
            this.tankView.setTankController(this);

            CurrentState = Idle;
            CurrentState.OnEnter(this);
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
                GameObject.Destroy(tankView.gameObject);
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