using UnityEngine;
using TankBattle.Interface;

namespace TankBattle
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Damager : MonoBehaviour
    {
        [SerializeField] private int damage = 20;
        private float life = 2f;

        private void Start()
        {
            Destroy(this.gameObject, life);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<IDamagable>() != null)
            {
                collision.gameObject.GetComponent<IDamagable>().GetDamage(damage);
            }
        }
    }
}