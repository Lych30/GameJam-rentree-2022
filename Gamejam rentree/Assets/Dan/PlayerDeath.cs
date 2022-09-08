using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject GameOverUI;
    public static PlayerDeath Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
    
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Death();
        }
    }


    public void Death()
    {
        PlayerMove.instance.canMove = false;
        GameOverUI.SetActive(true);
    }
}
