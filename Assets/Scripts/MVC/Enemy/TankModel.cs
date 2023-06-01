using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Enemy
{
    public class TankModel
    {
        private TankTypes tankType;
        private TankController tankController;
        public TankModel(TankTypes tankType)
        {
            this.tankType = tankType;
        }
        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}