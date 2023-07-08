using UnityEngine;
using TankBattle.MVC.Enemy;
using System.Collections;

namespace TankBattle.StateMachine
{
    public class Chase : State
    {
        private Transform player;
        IEnumerator coroutine;

        public override void OnEnter(TankController controller)
        {
            base.OnEnter(controller);
            coroutine = controller.tankView.ShootingBullet();
            Debug.Log("Enemy " + controller.tankModel.TankName + " tank is in Chase state");
        }

        public override void OnTrigger(TankController controller, Collider other)
        {
            base.OnTrigger(controller, other);

            player = other.gameObject.transform;
        }
        public override void OnUpdate(TankController controller)
        {
            base.OnUpdate(controller);

            controller.tankView.transform.LookAt(player);
            controller.tankView.transform.position =
                Vector3.MoveTowards(controller.tankView.transform.position, player.position, controller.agent.speed * Time.deltaTime);

            if (player != null && controller.bulletThrowen == true)
            {
                if (Vector3.Distance(controller.tankView.transform.position, player.position) <= controller.tankView.attackDistance)
                {
                    controller.ChangeState(controller.Attack);
                }
            }
        }
        public override void OnExit(TankController controller)
        {
            base.OnExit(controller);
            controller.tankView.StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}