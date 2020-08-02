using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilController : MonoBehaviour
{


    [SerializeField] float maxValue = 1f;
    float currentValue;

    void Start()
    {
        currentValue = 0f;
    }

    void updateValue()
    {
        FindObjectOfType<Clock>().setOil(currentValue);
    }
    public float GetValue()
    {
        return currentValue;
    }
    public void SpendOil()
    {
        currentValue = currentValue - 0.002f;
        updateValue();
    }
    public void AddOil()
    {
        if (currentValue >= 1f) { return; }
        currentValue = currentValue + 0.005f;
        updateValue();
    }
}
