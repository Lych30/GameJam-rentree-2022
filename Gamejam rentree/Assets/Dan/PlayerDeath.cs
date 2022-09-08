using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject GameOverUI;

    [Range(1, 20)]
    public int Fuel_Gained;
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
    
        switch (collision.tag)
        {
            case "Obstacle":
                Death();
                break;
            case "Fuel":
                GasBar.Instance.GainFuel(Fuel_Gained);
                break;
            default:
                break;
        }
    }


    public void Death()
    {
        PlayerMove.instance.canMove = false;
        GameOverUI.SetActive(true);
    }
}
