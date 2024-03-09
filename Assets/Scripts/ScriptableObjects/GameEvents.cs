using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game Event", menuName = "Scriptable Objects/Game Event")]
    public class GameEvents : ScriptableObject
    {
        List<GameEventListener> listeners = new List<GameEventListener>();

        public void TriggerEvent()
        {
            for(int i = 0; i < listeners.Count; i++)
            {
                listeners[i].OnEventTriggered();
            }
        }
        public void AddListeners(GameEventListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListeners(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}