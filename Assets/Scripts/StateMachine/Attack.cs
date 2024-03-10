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
    }
}