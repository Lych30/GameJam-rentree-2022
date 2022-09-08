using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public bool isDead = false;
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
            Debug.Log("est mort");
            PlayerMove.instance.canMove = false;
            isDead = true;
        }
    }

    void Update()
    {
        if (isDead)
        {
            GameOverUI.SetActive(true);
        } else
        {
            GameOverUI.SetActive(false);
        }
    }
}
