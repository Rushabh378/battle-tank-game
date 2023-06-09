using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Tank", menuName = "Scriptable Objects/Tank Type")]
    public class TankTypes : ScriptableObject
    {
        public int health = 100;
        public Damager bulletPrefab;
        public float movementSpeed = 17;
        public float rotationSpeed = 150;
    }
}