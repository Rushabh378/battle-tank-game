using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TankBattle.ScriptableObjects;

namespace TankBattle
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvents gameEvent;
        public UnityEvent onEventTriggred;

        private void OnEnable()
        {
            gameEvent.AddListeners(this);
        }
        private void OnDisable()
        {
            gameEvent.RemoveListeners(this);
        }
        public void OnEventTriggered()
        {
            onEventTriggred.Invoke();
        }
    }
}