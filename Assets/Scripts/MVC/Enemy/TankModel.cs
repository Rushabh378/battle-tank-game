using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Enemy
{
    public class TankModel
    {
        private TankTypes tankType;
        private TankController tankController;
        private float range;
        private int health;

        public TankModel(TankTypes tankType, float range)
        {
            this.tankType = tankType;
            this.health = tankType.health;
            this.range = range;
        }
        public float patrolingRange => range;
        public int Health { get => health; set => health = value; }

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}