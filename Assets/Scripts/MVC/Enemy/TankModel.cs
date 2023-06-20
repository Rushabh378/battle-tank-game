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

        public PoolTag Tag => PoolTag.normalTank;
        public Color TankColor => tankType.color;
        public float PatrolingRange => range;
        public int Health { get => health; set => health = value; }
        public GameObject Bullet => tankType.bulletPrefab.gameObject;
        public float Force { get => tankType.firePower; set => tankType.firePower = value; }

        public void SetTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}