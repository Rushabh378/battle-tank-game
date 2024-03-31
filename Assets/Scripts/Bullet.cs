using System.Collections;
using UnityEngine;
using TankBattle.Interface;

namespace TankBattle
{
    public class Bullet : DamageBehaviour, IPooledObject
    {
        [SerializeField] [Range(1f, 5f)] private float lifeTime = 2f;
        public void OnObjectPooled()
        {
            IEnumerator coroutine = DisActiveObjecIn(lifeTime);
            StartCoroutine(coroutine);
        }
        private IEnumerator DisActiveObjecIn(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }
    }
}