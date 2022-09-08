using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingGenerator : MonoBehaviour
{
    public bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            GameObject module = ObjectPool.instance.GetPooledObject();
            Debug.Log(module);

            if (module != null)
            {
                module.transform.position = gameObject.transform.position;
                module.SetActive(true);
                canSpawn = false;
            }
        }
    }
}
