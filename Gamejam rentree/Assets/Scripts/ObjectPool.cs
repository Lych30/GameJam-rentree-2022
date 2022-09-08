using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private List<GameObject> pooledObjects = new List<GameObject>();
    /*private int amountPool = 4;*/

    [SerializeField] private List<GameObject> modulePrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < modulePrefab.Count; i++)
        {
            pooledObjects.Add(modulePrefab[i]);
        }  
    }
    // Start is called before the first frame update

    public GameObject GetPooledObject()
    {
        GameObject randomModule = pooledObjects[Random.Range(0, pooledObjects.Count)];
        /*for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }*/

        if (!randomModule.activeInHierarchy)
        {
            return randomModule;
        }

        return null;
    }
}
