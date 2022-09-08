using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool isDead = false;

    
    

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("est mort");
        if (collision.gameObject.CompareTag("Player"))
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
