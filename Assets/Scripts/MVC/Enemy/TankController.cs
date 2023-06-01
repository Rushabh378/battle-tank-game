using UnityEngine;

namespace TankBattle.MVC.Enemy
{
    public class TankController
    {
        private TankModel tankModel;
        private EnemyTankView tankView;

        public TankController(TankModel tankModel, EnemyTankView tankView, Vector3 position)
        {
            this.tankModel = tankModel;
            this.tankView = GameObject.Instantiate<EnemyTankView>(tankView, position, Quaternion.identity);

            this.tankModel.setTankController(this);
            this.tankView.setTankController(this);
        }
    }
}