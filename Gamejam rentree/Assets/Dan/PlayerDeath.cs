using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool isDead = false;

    
    

    void OnTriggerEnter(Collider collision)
    {
   
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("est mort");
            PlayerMove.instance.canMove = false;
            isDead = true;
        }
    }

    void Update()
    {
        
    }
}
