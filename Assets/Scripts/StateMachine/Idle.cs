using UnityEngine;
using TankBattle.MVC.Enemy;
namespace TankBattle.StateMachine
{
    public class Idle : State
    {
        public override void OnEnter(TankController controller)
        {
            base.OnEnter(controller);

        }
    }
}