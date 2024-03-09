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
            Debug.Log("Enemy " + controller.tankModel.TankName + " tank is in Attack state");
            base.OnEnter(controller);

            coroutine = controller.tankView.ShootingBullet();
            controller.tankView.StartCoroutine(coroutine);
        }
    }
}