using UnityEngine;

namespace TankBattle.MVC
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;

        public TankController(TankModel tankModel,TankView tankView)
        {
            this.tankModel = tankModel;
            this.tankView = tankView;

            this.tankModel.setTankController(this);
            this.tankView.setTankController(this);
        }

        public void SpawnTank(Vector3 position)
        {
            GameObject.Instantiate(tankView.gameObject, position, Quaternion.identity);
        }
    }
}
