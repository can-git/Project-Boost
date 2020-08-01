using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilController : MonoBehaviour
{

    Slider slider;
    [SerializeField] int maxValue = 1000;
    int currentValue;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = maxValue;
        currentValue = maxValue;
    }

    void updateValue()
    {
        slider.value = currentValue;
    }
    public int GetValue()
    {
        return currentValue;
    }
    public void SpendOil()
    {
        currentValue--;
        updateValue();
    }
    public void AddOil()
    {
        currentValue = currentValue + 2;
        updateValue();
    }
}
