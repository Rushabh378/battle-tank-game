using UnityEngine;
using TankBattle.MVC.Enemy;
namespace TankBattle.StateMachine
{
    public abstract class State
    {
        public virtual void OnEnter(TankController controller)
        {

        }
        public virtual void OnUpdate(TankController controller)
        {

        }
        public virtual void OnCollision(TankController controller, Collision collision)
        {

        }
        public virtual void OnTrigger(TankController controller, Collider other)
        {

        }
        public virtual void OnExit(TankController controller)
        {

        }
    }
}