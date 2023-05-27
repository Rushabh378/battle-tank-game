using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC
{
    public class TankModel
    {
        private TankController tankController;
        private TankTypes tankType;
        public TankModel()
        {
            this.tankType = new();
        }
        public TankModel(TankTypes tankType)
        {
            this.tankType = tankType;
        }
        public string Name { get { return tankType.tankName; } }
        public int Health { get { return tankType.health; } }
        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}
