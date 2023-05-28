using UnityEngine;

namespace TankBattle.MVC
{
    public class TankModel
    {
        private TankController tankController;

        public TankModel()
        {

        }

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}
