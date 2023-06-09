using UnityEngine;
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

        public void Update()
        {
            tankController.Patrol();
        }

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

        public void GetDamage(int damage)
        {
            tankController.MinusHealth(damage);
        }
    }
}