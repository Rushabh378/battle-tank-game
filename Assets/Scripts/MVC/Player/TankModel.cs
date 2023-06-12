using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Player
{
    public class TankModel
    {
        private TankController tankController;
        private TankTypes tankType;
        private int health;
       
        public TankModel(TankTypes tankType)
        {
            this.tankType = tankType;
            this.health = tankType.health;
        }
        public int Health { get => health; set => health = value; }
        public GameObject bullet => tankType.bulletPrefab.gameObject;
        public float MovementSpeed => tankType.movementSpeed;
        public float RotationSpeed => tankType.rotationSpeed;
        public float Force => tankType.firePower;

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}
