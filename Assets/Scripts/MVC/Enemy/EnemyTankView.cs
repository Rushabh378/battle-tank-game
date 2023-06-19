using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TankBattle.Interface;
using TankBattle.Singleton;

namespace TankBattle.MVC.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour, IDamagable
    {
        public Transform firePosition;
        public float attackDistance = 5f;
        private TankController tankController;
        [HideInInspector] internal NavMeshAgent agent;

        public void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            tankController.SetAgent(agent);

            tankController.ChangeState(tankController.Patrol);
        }

        public void Update()
        {
            tankController.CurrentState.OnUpdate(tankController);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") == true)
            {
                agent.isStopped = true;
                if(tankController.CurrentState == tankController.Patrol)
                {
                    tankController.ChangeState(tankController.Chase);
                    tankController.CurrentState.OnTrigger(tankController, other);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                agent.isStopped = false;
                tankController.ChangeState(tankController.Patrol);
            }
        }

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

        public void GetDamage(int damage)
        {
            tankController.MinusHealth(damage);
        }

        public IEnumerator ShootingBullet()
        {
            tankController.bulletThrowen = false;

            GameObject bullet = GameObjectPooler.Instance.GetFromPool(PoolTag.normalBullet, firePosition.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * tankController.tankModel.Force, ForceMode.Impulse);

            yield return new WaitForSeconds(3f);
            tankController.bulletThrowen = true;
            if(tankController.CurrentState == tankController.Attack)
            {
                tankController.ChangeState(tankController.Chase);
            }
        }
        
        private void OnDestroy()
        {
            tankController.CurrentState.OnExit(tankController);
        }

    }
}