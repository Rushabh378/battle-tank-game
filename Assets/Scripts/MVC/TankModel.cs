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
        public string Name { get { return tankType.tankName; } set => tankType.tankName = value; }
        public Color Color { get { return tankType.color; } set => tankType.color = value; }
        public int Health => tankType.health;
        public int Damage { get { return tankType.damage; } set => tankType.damage = value; }
        public float MovementSpeed { get { return tankType.movementSpeed; } set => tankType.movementSpeed = value; }
        public float RotationSpeed { get { return tankType.rotationSpeed; } set => tankType.rotationSpeed = value; }

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}
