using UnityEngine;

namespace TankBattle.Singleton
{
    public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
    {

        private static T instance;
        public static T Singleton { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

