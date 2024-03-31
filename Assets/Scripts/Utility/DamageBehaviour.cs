using UnityEngine;
using TankBattle.Interface;
using System.Collections;

namespace TankBattle
{
    [RequireComponent(typeof(Collider))]
    public abstract class DamageBehaviour : MonoBehaviour
    {
        [SerializeField] private int damage = 20;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<IDamagable>() != null)
            {
                collision.gameObject.GetComponent<IDamagable>().GetDamage(damage);
            }
        }
    }
}