using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TankBattle.Interface;

namespace TankBattle.MVC.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour, IDamagable
    {
        public Transform FirePosition;
        public float AttackDistance = 5f;
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
                tankController.ChangeState(tankController.Chase);
                tankController.CurrentState.OnTrigger(tankController, other);
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

        private void OnCollisionEnter(Collision collision)
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if(damagable != null)
            {
                damagable.GetDamage(100);
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
            GameObject bullet = Instantiate(tankController.tankModel.Bullet, FirePosition.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * tankController.tankModel.Force, ForceMode.Impulse);
            yield return new WaitForSeconds(5f);
            tankController.bulletThrowen = true;
        }

    }
}