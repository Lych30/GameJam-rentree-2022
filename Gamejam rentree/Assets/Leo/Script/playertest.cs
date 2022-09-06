using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertest : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    Transform destination;
    [SerializeField] int index = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            index++;

            if(index == 6)
            {
                index = 0;
            }
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(-60, 0,0));

            Debug.Log(index);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            index--;

            if (index == -1)
            { 
                index = 5;
            }
            transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(60,0,0));
            Debug.Log(index);
        }
        
        AtoB(points[index]);
    }
    void AtoB(Transform destination)
    {
        //transform.position = destination.position;
        transform.position = Vector3.Lerp(transform.position, destination.position,10*Time.deltaTime);
    }
}
