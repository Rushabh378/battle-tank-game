using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Player
{
    public class TankModel
    {
        private TankController tankController;
        private TankTypes tankType;
        private float force = 20f;
       
        public TankModel(TankTypes tankType)
        {
            this.tankType = tankType;
        }
        public int Health { get => tankType.health; set => tankType.health = value; }
        public GameObject bullet => tankType.bulletPrefab.gameObject;
        public float MovementSpeed => tankType.movementSpeed;
        public float RotationSpeed => tankType.rotationSpeed;

        public float Force => force;

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}
