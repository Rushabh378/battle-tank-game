using System;
using System.Collections;
using UnityEngine;
using TankBattle.Singleton;

namespace TankBattle.MVC.Player
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;
        private Rigidbody rigidBody;

        public static event Action OnPlayerShoot;
        public static event Action OnPlayerDeath;

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

        internal void ShootingBullet(Vector3 position)
        {
            GameObject bullet = GameObjectPooler.Singleton.FetchFromPool(PoolTag.normalBullet, position, tankView.transform.rotation);
            if(bullet != null)
            {
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * tankModel.Force, ForceMode.Impulse);
                OnPlayerShoot?.Invoke();
            }
        }

        internal void MinusHealth(int damage)
        {
            tankModel.Health -= damage;
            if (tankModel.Health <= 0)
            {
                OnPlayerDeath.Invoke();
                IEnumerator destroyEverything = tankView.StartDestroyingEverything();
                tankView.StartCoroutine(destroyEverything);
            }
        }
    }
}
