using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    Slider slider;
    [SerializeField] float maxValue = 1f;
    int currentValue;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setSpeed(int speedValue)
    {
        slider.value = speedValue;
    }
}
