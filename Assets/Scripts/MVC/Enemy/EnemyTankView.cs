using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TankBattle.Interface;
using TankBattle.Singleton;

namespace TankBattle.MVC.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour, IDamagable, IPooledObject
    {
        [SerializeField] private Transform firePosition;
        [Range(1f, 10f)] public float attackDistance = 5f;

        private NavMeshAgent agent;
        private TankController tankController;

        public void SetTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

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
            if (other.gameObject.GetComponent<MVC.Player.TankView>() != null)
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

        public void GetDamage(int damage)
        {
            tankController.MinusHealth(damage);
        }

        public IEnumerator ShootingBullet()
        {
            GameObject bullet = GameObjectPooler.Singleton.FetchFromPool(PoolTag.normalBullet, firePosition.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * tankController.tankModel.Force, ForceMode.Impulse);

            yield return new WaitForSeconds(3f);

            if(tankController.CurrentState == tankController.Attack)
            {
                tankController.ChangeState(tankController.Chase);
            }
        }

        public void OnObjectPooled()
        {
            //throw new System.NotImplementedException();
        }
    }
}