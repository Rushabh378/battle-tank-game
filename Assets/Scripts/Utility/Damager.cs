using UnityEngine;
using TankBattle.Interface;
using System.Collections;

namespace TankBattle
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Damager : MonoBehaviour, IPooledObject
    {
        [SerializeField] private int damage = 20;
        private float life = 2f;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<IDamagable>() != null)
            {
                collision.gameObject.GetComponent<IDamagable>().GetDamage(damage);
            }
        }

        public void OnObjectPooled()
        {
            IEnumerator coroutine = DisActiveObjecIn(life);
            StartCoroutine(coroutine);
        }

        private IEnumerator DisActiveObjecIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }
    }
}