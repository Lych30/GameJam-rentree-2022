using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject Explosion;
    public GameObject Shield;
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
                StartCoroutine(deactivateFuel(collision.gameObject));
                break;
            default:
                break;
        }
    }


    public void Death()
    {
        if (!hasShield)
        {
            Explosion.SetActive(true);
            GetComponent<MeshRenderer>().enabled = false;
            SoundManager.Instance.Play(GetComponent<playertest>().clips[0]);
            
            hasShield = true;
            PlayerMove.instance.canMove = false;
            GameOverUI.SetActive(true);
        }
        else
        {
            Shield.SetActive(false);
            SoundManager.Instance.Play(GetComponent<playertest>().clips[6]);
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
        SoundManager.Instance.Play(GetComponent<playertest>().clips[5]);
        Shield.SetActive(true);
        hasShield = true;
        canShield = false;
        yield return new WaitForSeconds(time);
        hasShield = false;
        Shield.SetActive(false);
        yield return new WaitForSeconds(shieldCooldown);
        canShield = true;
        SoundManager.Instance.Play(GetComponent<playertest>().clips[6]);
    }
    IEnumerator deactivateFuel(GameObject Fuel)
    {
        Fuel.SetActive(false);
        yield return new WaitForSeconds(1);
        Fuel.SetActive(true);
    }
}
