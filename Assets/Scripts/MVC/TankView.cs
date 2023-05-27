using UnityEngine;
using TankBattle.ScriptableObjects;

namespace TankBattle.MVC
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;

        public TankView()
        {
            
        }

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}
