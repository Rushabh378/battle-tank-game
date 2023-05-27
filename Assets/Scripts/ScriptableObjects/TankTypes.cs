using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Tank", menuName = "Scriptable Objects/Tank Type")]
    public class TankTypes : ScriptableObject
    {
        public string tankName = "Tank Name";
        public Color color;
        public int health = 100;
        public int damage = 20;
        public int movementSpeed = 12;
    }
}