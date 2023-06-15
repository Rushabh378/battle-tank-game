using UnityEngine;
using TankBattle.MVC.Enemy;

namespace TankBattle.StateMachine
{
    public class Chase : State
    {
        private Transform player;

        public override void OnTrigger(TankController controller, Collider other)
        {
            base.OnTrigger(controller, other);

            controller.target = player = other.gameObject.transform;

            controller.tankView.transform.LookAt(player);
            controller.tankView.transform.position = 
                Vector3.MoveTowards(controller.tankView.transform.position, player.position, controller.agent.speed * Time.deltaTime);
        }
        public override void OnUpdate(TankController controller)
        {
            base.OnUpdate(controller);

            if(player != null)
            {
                if (Vector3.Distance(controller.tankView.transform.position, player.position) <= controller.tankView.AttackDistance)
                {
                    controller.ChangeState(controller.Attack);
                }
            }
        }
    }
}