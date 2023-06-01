using UnityEngine;

namespace TankBattle.MVC.Enemy
{
    public class EnemyTankView : MonoBehaviour
    {
        private TankController tankController;

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

    }
}