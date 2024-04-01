using System.Collections.Generic;
using UnityEngine;
using TankBattle.Interface;

namespace TankBattle.Singleton
{
    public class GameObjectPooler : GenericSingleton<GameObjectPooler>
    {
        private Dictionary<PoolTag, Queue<GameObject>> poolDictionary;
  
        [System.Serializable] private class Pool
        {
            public PoolTag tag;
            public GameObject prefab;
            public int size;
        }
        [SerializeField] private List<Pool> pools;

        private void OnEnable()
        {
            poolDictionary = new Dictionary<PoolTag, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectsPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectsPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectsPool);
            }
        }

        public GameObject FetchFromPool(PoolTag tag, Vector3 position, Quaternion rotation)
        {

            if(poolDictionary.ContainsKey(tag) == false)
            {
                Debug.LogWarning("there is no pool found with tag : " + tag);
                return null;
            }

            GameObject objectToGet = poolDictionary[tag].Dequeue();

            objectToGet.transform.position = position;
            objectToGet.transform.rotation = rotation;
            objectToGet.SetActive(true);

            IPooledObject pooled = objectToGet.GetComponent<IPooledObject>();
            if(pooled != null)
            {
                pooled.OnObjectPooled();
            }

            poolDictionary[tag].Enqueue(objectToGet);

            return objectToGet;
        }
    }
}