using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public int Fuel;

    public Slider FuelBar;

    [Range(1, 50)]
    public int MaxFuel;

    [Range(1, 5)]
    public float TimeBtwLoss;

    float DecreasingtimeLoss;
    public static GasBar instance;


    public static GasBar Instance { get; private set; }
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

    void Start()
    {
        FuelBar.maxValue = MaxFuel;
        FuelBar.value = MaxFuel;
        DecreasingtimeLoss = TimeBtwLoss;
    }
    void Update()
    {
        if (PlayerMove.instance.canMove)
        {
            if(DecreasingtimeLoss <= 0)
            {
                DecreasingtimeLoss = TimeBtwLoss;
                LooseFuel(1);
            }
            else
            {
                DecreasingtimeLoss -= Time.deltaTime;
            }
        }
    }
    void LooseFuel(int amount)
    {
        FuelBar.value -= amount;
        if(FuelBar.value <= 0)
        {
            PlayerDeath.Instance.Death();
        }
    }
    public void GainFuel(int amount)
    {
        FuelBar.value += amount;
     
    }

}
