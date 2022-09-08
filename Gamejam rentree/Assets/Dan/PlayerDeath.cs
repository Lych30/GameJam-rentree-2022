using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject GameOverUI;

    public static PlayerDeath instance;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
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
