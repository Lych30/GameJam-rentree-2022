using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public List<GameObject> pooledObjects = new List<GameObject>();

    [SerializeField] float rythmChangePos = 29.9f;
    [SerializeField] float varRythm = 42f;

    public List<GameObject> modulePrefab;

    [SerializeField] bool rythmCanChange = true;

    GameObject player;
    PlayerMove playerMove;

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
        playerMove = player.GetComponentInParent<PlayerMove>();
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
        if (rythmCanChange)
        {
            rythmChangePos += (varRythm * Random.Range(3, 6));
            rythmCanChange = false;

        }
        if ((int)player.transform.position.z == (int)rythmChangePos)
        {
            playerMove.LevelSpeedMultiplier = Random.Range(0.5f, 1.5f);
            rythmCanChange = true;
        }

    }   
}
