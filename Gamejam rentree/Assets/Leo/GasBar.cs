using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    // Start is called before the first frame update
    public int Fuel;
    public Slider FuelBar;
    public int MaxFuel;
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
        FuelBar.value = Fuel;
        FuelBar.maxValue = MaxFuel;

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
