using System.Collections;
using UnityEngine;
using TankBattle.MVC.Enemy;

namespace TankBattle.StateMachine
{
    public class Attack : State
    {
        IEnumerator coroutine;
        public override void OnEnter(TankController controller)
        {
            base.OnEnter(controller);
            coroutine = controller.tankView.ShootingBullet();
            controller.tankView.StartCoroutine(coroutine);
        }

        public override void OnUpdate(TankController controller)
        {
            base.OnUpdate(controller);

            if (controller.target != null && controller.bulletThrowen)
            {
                if (Vector3.Distance(controller.tankView.transform.position, controller.target.position) <= controller.tankView.AttackDistance)
                {
                    controller.tankView.StartCoroutine("ShootingBullet");
                }
                else
                {
                    controller.ChangeState(controller.Chase);
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