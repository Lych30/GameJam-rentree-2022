using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleObject : MonoBehaviour
{
    PoolingGenerator generator;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<PoolingGenerator>(); ;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distFromPlayer = (player.transform.position.z - gameObject.transform.position.z);
        if (distFromPlayer > 15)
        {
            generator.canSpawn = true;
            gameObject.SetActive(false);
        }
    }
}
