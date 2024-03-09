using UnityEngine;
using TankBattle.MVC.Enemy;
namespace TankBattle.StateMachine
{
    public class Patrol : State
    {
        public override void OnEnter(TankController controller)
        {
            base.OnEnter(controller);
            Debug.Log("Enemy " + controller.tankModel.TankName + " tank is in Patrol state");
        }
        public override void OnUpdate(TankController controller)
        {
            base.OnUpdate(controller);
            controller.agent.stoppingDistance = 5f;
            if (controller.agent.remainingDistance <= controller.agent.stoppingDistance)
            {
                Vector3 point = RandomPoint(controller.center, controller.tankModel.PatrolingRange);
                if (point != Vector3.zero)
                {
                    controller.agent.SetDestination(point);
                }
            }
        }
        Vector3 RandomPoint(Vector3 center, float range)
        {

            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            UnityEngine.AI.NavMeshHit hit;
            Vector3 result;
            if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, range, 1))
            {
                result = hit.position;
                return result;
            }

            result = Vector3.zero;
            return result;
        }
    }
}