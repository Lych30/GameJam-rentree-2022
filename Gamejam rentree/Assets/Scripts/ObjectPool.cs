using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> pooledObjects = new List<GameObject>();

    float rythmChangePos = 29.9f;
    float varRythm = 42f;

    public List<GameObject> modulePrefab;

    GameObject player;

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

        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

    void Update()
    {
        rythmChangePos += (varRythm * Random.Range(3, 6));
        if(player.transform.position.z == rythmChangePos)
        {

        }
    }
}
