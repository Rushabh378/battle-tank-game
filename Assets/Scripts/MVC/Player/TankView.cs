using UnityEngine;
using System.Collections;
using System;

namespace TankBattle.MVC.Player
{
    public class TankView : MonoBehaviour, IDamagable
    {
        [SerializeField] internal Transform shootPosition;
        private TankController tankController;
        private float movement;
        private float rotation;
        private IEnumerator coroutine;

        public void setTankController(TankController tankController)
        {
            this.tankController = tankController;
        }

        public void Update()
        {
            getMovements();

            if (Input.GetMouseButtonDown(0))
            {
                tankController.ShootingBullet(shootPosition.position);
            }
        }

        public void FixedUpdate()
        {
            
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

        public void GetDamage(int damage)
        {
            tankController.MinusHealth(damage);
        }

        internal IEnumerator StartDestroyingEverything()
        {
            coroutine = DestroyEnemyTanks();
            yield return StartCoroutine(coroutine);

            coroutine = DestroyOtherThings();
            StartCoroutine(coroutine);
        }

        private IEnumerator DestroyEnemyTanks()
        {
            Enemy.EnemyTankView[] enemyTanks = FindObjectsByType<Enemy.EnemyTankView>(FindObjectsSortMode.None);
            for (int i = 0; i < enemyTanks.Length; i++)
            {
                if(enemyTanks[i] != null)
                {
                    Destroy(enemyTanks[i].gameObject);
                }
                yield return new WaitForSeconds(1f);
            }
        }

        private IEnumerator DestroyOtherThings()
        {
            
            CapsuleCollider[] capsules = FindObjectsByType<CapsuleCollider>(FindObjectsSortMode.None);
            for(int i = 0; i < capsules.Length; i++)
            {
                if(capsules[i] != null)
                {
                    Destroy(capsules[i].gameObject);
                }
                yield return new WaitForSeconds(0.4f);
            }
            capsules = null;
            MeshFilter[] mesh = FindObjectsByType<MeshFilter>(FindObjectsSortMode.None);
            for (int i = 0; i < mesh.Length; i++)
            {
                if (mesh[i] != null)
                {
                    Destroy(mesh[i].gameObject);
                }
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}
