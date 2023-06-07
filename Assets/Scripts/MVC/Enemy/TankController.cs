using UnityEngine;
using UnityEngine.AI;

namespace TankBattle.MVC.Enemy
{
    public class TankController
    {
        private TankModel tankModel;
        private EnemyTankView tankView;
        private NavMeshHit closestHit;
        private Vector3 point;
        private Vector3 center;

        public TankController(TankModel tankModel, EnemyTankView tankView, Vector3 position)
        {
            this.tankModel = tankModel;

            if (NavMesh.SamplePosition(position, out closestHit, 100f, 1))
            {
                position = center = closestHit.position;
                this.tankView = GameObject.Instantiate<EnemyTankView>(tankView, position, Quaternion.identity);
            }
            else
            {
                Debug.Log("NavMesh Agent isn't working yet.");
            }

            this.tankModel.setTankController(this);
            this.tankView.setTankController(this);
        }

        internal void Patrol()
        {
            tankView.agent.stoppingDistance = 5f;
            if(tankView.agent.remainingDistance <= tankView.agent.stoppingDistance)
            {
                point = RandomPoint(center, tankModel.patrolingRange);
                if (point != Vector3.zero)
                {
                    tankView.agent.SetDestination(point);
                }
            }
        }

        Vector3 RandomPoint(Vector3 center, float range)
        {

            Vector3 randomPoint = center + Random.insideUnitSphere * range;  
            NavMeshHit hit;
            Vector3 result;
            if (NavMesh.SamplePosition(randomPoint, out hit, range, 1)) 
            {
                result = hit.position;
                return result;
            }

            result = Vector3.zero;
            return result;
        }
    }
}