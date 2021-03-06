﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilController : MonoBehaviour
{

    float currentValue;

    void Start()
    {
        currentValue = 1f;
        this.gameObject.GetComponent<Pointer>().setOil(currentValue);
    }

    void updateValue()
    {
        this.gameObject.GetComponent<Pointer>().setOil(currentValue);
        //FindObjectOfType<Pointer>().setOil(currentValue);
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
