using UnityEngine;

namespace TankBattle.MVC
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;
        private Rigidbody rigidBody;
        
        //Private-   _variableName
        //Serializefield/arguments-   variableName
        //public-  VariableName
        //constants  VARIABLE_NAME
                            


        public TankController(TankModel tankModel,TankView tankView, Vector3 position)
        {
            this.tankModel = tankModel;
            //tankView.gameObject.GetComponentsInChildren<Material>();
            this.tankView = GameObject.Instantiate<TankView>(tankView, position, Quaternion.identity);

            this.tankModel.setTankController(this);
            this.tankView.setTankController(this);

            rigidBody = this.tankView.gameObject.GetComponent<Rigidbody>();
        }

        public void MoveTank(float movement)
        {
            rigidBody.AddForce(tankView.transform.forward * movement * tankModel.MovementSpeed,ForceMode.Acceleration);
        }
        public void RotateTank(float rotation)
        {
            Vector3 yRotation = new(0f, rotation * tankModel.RotationSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(yRotation * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
            
        }
    }
}
