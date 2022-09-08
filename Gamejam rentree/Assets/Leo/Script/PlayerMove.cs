using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float SpeedMultiplier = 1;
    public bool canMove = true;

    public static PlayerMove instance;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    void Update()
    {
<<<<<<< Updated upstream
        SpeedMultiplier += Time.deltaTime / 15;
        SpeedMultiplier = Mathf.Clamp(SpeedMultiplier, 1,5);
       
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime*4 * SpeedMultiplier;
=======
        if (canMove)
        {
            SpeedMultiplier += Time.deltaTime / 10;
            SpeedMultiplier = Mathf.Clamp(SpeedMultiplier, 1,4);

            transform.position += new Vector3(0, 0, 1) * Time.deltaTime*4 * SpeedMultiplier;
        }
>>>>>>> Stashed changes
    }
}
