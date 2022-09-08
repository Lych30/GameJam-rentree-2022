using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    [SerializeField] 
    private int distance;
    void Start()
    {
        distance = 0;
    }

    void Update()
    {
        distance += 1;
        transform.GetComponent<Text>().text = distance.ToString();
    }
}
