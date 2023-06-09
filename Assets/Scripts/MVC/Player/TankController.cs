using System;
using UnityEngine;

namespace TankBattle.MVC.Player
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;
        private Rigidbody rigidBody;

        private Material[] tankMaterial;
                            


        public TankController(TankModel tankModel,TankView tankView, Vector3 position)
        {
            this.tankModel = tankModel;
            this.tankView = GameObject.Instantiate<TankView>(tankView, position, Quaternion.identity);

            this.tankModel.setTankController(this);
            this.tankView.setTankController(this);

            Camera.main.transform.parent = this.tankView.transform;

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

        public void ShootingBullet(Vector3 position)
        {
            GameObject bullet = GameObject.Instantiate(tankModel.bullet, position, tankView.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * tankModel.Force, ForceMode.Impulse);
        }
    }
}