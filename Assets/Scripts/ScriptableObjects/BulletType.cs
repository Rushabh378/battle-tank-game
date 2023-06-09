using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Scriptable Objects/Bullet Type")]
    public class BulletTypes : ScriptableObject
    {
        public int Damage;
        [Range(0.1f, 5f)]
        public float life = 2;
    }
}