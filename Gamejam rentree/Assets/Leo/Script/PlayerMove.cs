using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float SpeedMultiplier = 1;
    public float LevelSpeedMultiplier = 1;
    float SlowDownFactor = 1;
    public bool canMove = true;
    public int SlowDownCost; 
    public float SlowDownDuration;

    public GameObject SlowDownUI;

    public static PlayerMove instance;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);

        instance = this;
    }

    void Update()
    {

        if (canMove)
        {
        SpeedMultiplier += Time.deltaTime / 15;
        SpeedMultiplier = Mathf.Clamp(SpeedMultiplier, 1, 3);
    
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime* 4 * SpeedMultiplier / SlowDownFactor * LevelSpeedMultiplier;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if(GasBar.Instance.FuelBar.value > SlowDownCost && SlowDownFactor != 2)
            {
                GasBar.Instance.FuelBar.value -= SlowDownCost;
                StartCoroutine(SlowDownCoroutine(SlowDownDuration));
            }
        }
    }
    IEnumerator SlowDownCoroutine(float Time)
    {
        SlowDownUI.SetActive(false);
        SlowDownFactor = 2;
        yield return new WaitForSeconds(Time);
        SlowDownFactor = 1;
        SlowDownUI.SetActive(true);
    }
}
