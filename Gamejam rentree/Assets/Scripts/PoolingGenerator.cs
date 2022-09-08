using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingGenerator : MonoBehaviour
{
    [SerializeField] Transform loadingPosition;
    public bool canSpawn;
    [SerializeField] private List<GameObject> moduleList = new List<GameObject>();
    [SerializeField] private List<GameObject> usedModule = new List<GameObject>();
    GameObject actualModule;
    bool moduleNotUsed;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < moduleList.Count; i++)
        {
            moduleNotUsed = false;
            while (!moduleNotUsed)
            {
                actualModule = moduleList[Random.Range(0, moduleList.Count)];
                if (!usedModule.Contains(actualModule))
                {
                    moduleNotUsed = true;
                }
            }
            usedModule.Add(actualModule);
            GameObject moduleCharged = Instantiate(actualModule);
            moduleCharged.transform.position = loadingPosition.position;
            loadingPosition.transform.position = loadingPosition.transform.position + new Vector3(0, 0, 42f);
            ObjectPool.instance.modulePrefab.Add(moduleCharged);
            moduleCharged.AddComponent<ModuleObject>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            GameObject module = ObjectPool.instance.GetPooledObject();

            if (module != null)
            {
                module.transform.position = gameObject.transform.position;
                module.SetActive(true);
                canSpawn = false;
            }
        }
    }
}
