using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject GameOverUI;

    [Range(1, 20)]
    public int Fuel_Gained;
    public float time;
    public float shieldCooldown;
    public bool canShield = true;
    public static PlayerDeath Instance { get; private set; }
    public bool hasShield = false;
    private void Awake()
    {
        GameOverUI.SetActive(false);

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
        if (!hasShield)
        {
            PlayerMove.instance.canMove = false;
            GameOverUI.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && PlayerMove.instance.canMove && canShield)
        {
            StartCoroutine(ShieldDuration(time));
        }

        if (GameOverUI.activeSelf && Input.anyKey)
        {
            SceneManager.LoadScene("FinalGame v2");
        }
    }

    IEnumerator ShieldDuration(float time)
    {
        Debug.Log("shield");
        hasShield = true;
        canShield = false;
        yield return new WaitForSeconds(time);
        hasShield = false;
        yield return new WaitForSeconds(shieldCooldown);
        canShield = true;
    }
}
