using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Player
{
    public class TankModel
    {
        private TankController tankController;
        private TankTypes tankType;
       
        public TankModel(TankTypes tankType)
        {
            this.tankType = tankType;
        }
        public int Health => tankType.health;
        public int Damage => tankType.damage;
        public float MovementSpeed => tankType.movementSpeed;
        public float RotationSpeed => tankType.rotationSpeed;

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}
