using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Enemy
{
    
    public class EnemyTankServices : MonoBehaviour
    {
        private TankModel tankModel;
        [SerializeField] private TankTypes tankType;
        [SerializeField] [Range(1f,45f)] private float patrolingRange = 30;
        private TankController tankController;

        public void Start()
        {
            tankModel = new(tankType, patrolingRange);
            tankController = new(tankModel, transform.position);
        }
    }
}