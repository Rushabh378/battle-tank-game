using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC.Enemy
{
    public class EnemyTankServices : MonoBehaviour
    {
        private TankModel tankModel;
        [SerializeField] private EnemyTankView tankView;
        [SerializeField] private TankTypes tankType;
        private TankController tankController;

        public void Start()
        {
            tankModel = new(tankType);
            tankController = new(tankModel, tankView, transform.position);
        }
    }
}