using UnityEngine;

namespace TankBattle.MVC.Player
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private float movement;
        private float rotation;

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

        public void FixedUpdate()
        {
            getMovements();
            if(movement != 0f)
            {
                tankController.MoveTank(movement);
            }
            if(rotation != 0)
            {
                tankController.RotateTank(rotation);
            }
        }

        public void getMovements()
        {
            movement = Input.GetAxis("Vertical");
            rotation = Input.GetAxis("Horizontal");
        }
    }
}
