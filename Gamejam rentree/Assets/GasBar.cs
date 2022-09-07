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
    void Start()
    {
        FuelBar.value = Fuel;
        FuelBar.maxValue = MaxFuel;

        DecreasingtimeLoss = TimeBtwLoss;
    }
    void Update()
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
    void LooseFuel(int amount)
    {
        FuelBar.value -= amount;
        if(FuelBar.value <= 0)
        {
            Debug.Log("Stop");
        }
    }
    void GainFuel(int amount)
    {
        FuelBar.value += amount;
     
    }

}
