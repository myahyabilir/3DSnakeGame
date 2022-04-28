using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Basit bir object pooler
/// </summary>
public class PoolController : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int count;
        public Transform parent = null;
    }

    public static PoolController Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> dict;

    public Dictionary<string, int> dictToSend; 

    void Start(){
        dict = new Dictionary<string, Queue<GameObject>>();
        dictToSend = new Dictionary<string, int>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
                for(int i = 0; i < pool.count; i++)
                    {
                        GameObject obj = Instantiate(pool.prefab);
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);

                        if(pool.parent != null)
                        {
                            obj.transform.SetParent(pool.parent);
                        }

                    }
            dict.Add(pool.tag, objectPool);
            dictToSend.Add(pool.tag, pool.count);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = dict[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        dict[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}
