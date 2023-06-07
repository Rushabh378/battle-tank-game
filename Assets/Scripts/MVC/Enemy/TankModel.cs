using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Enemy
{
    public class TankModel
    {
        private TankTypes tankType;
        private TankController tankController;
        private Transform destination;
        private float range = 50;

        public TankModel(TankTypes tankType, float range)
        {
            this.tankType = tankType;
            this.range = range;
        }

        public Transform Destination { get => destination; set => destination = value; }
        public float patrolingRange => range;

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}