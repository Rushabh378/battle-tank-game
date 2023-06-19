using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Singleton
{
    public class GameObjectPooler : GenericSingleton<GameObjectPooler>
    {
        private Dictionary<string, Queue<GameObject>> poolDictionary;
  
        [System.Serializable] private class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }
        [SerializeField] private List<Pool> pools;

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach(Pool pool in pools)
            {
                Queue<GameObject> objectsPool = new Queue<GameObject>();

                for(int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectsPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectsPool);
            }
        }

        public GameObject GetFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if(poolDictionary.ContainsKey(tag) == false)
            {
                return null;
            }

            GameObject objectToGet = poolDictionary[tag].Dequeue();

            objectToGet.SetActive(true);
            objectToGet.transform.position = position;
            objectToGet.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objectToGet);

            return objectToGet;
        }
    }
}