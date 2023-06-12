using System.Collections;
using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Tank Type Array", menuName = "Scriptable Objects/ Tank Type Array")] 
    public class TankTypeArray : ScriptableObject
    {
        public TankTypes[] tankTypes;
    }
}