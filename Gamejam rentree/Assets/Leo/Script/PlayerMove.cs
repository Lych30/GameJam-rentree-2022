using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float SpeedMultiplier = 1;
    // Update is called once per frame
    void Update()
    {
        SpeedMultiplier += Time.deltaTime / 15;
        SpeedMultiplier = Mathf.Clamp(SpeedMultiplier, 1,5);
       
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime*4 * SpeedMultiplier;
    }
}
