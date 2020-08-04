using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pointer : MonoBehaviour
{

    public Material speedMat;
    public Material oilMat;
    public TextMesh speedText;
    public TextMesh minuteText;
    float speed;
    bool state = false;

    void Start()
    {
        setSpeed(0);
        setOil(0);
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        //speed = FindObjectOfType<Rocket>().getVelocity();
        
        setSpeed(speed);
        if (state)
        {
            //setSpeed(speed);
        }
        else
        {
            //decreaseSpeed(speed);
        }
    }

    public void setOil(float oilValue)
    {
        minuteText.text = oilValue.ToString("F2");
        oilMat.SetFloat("_Fillpercentage", oilValue);
    }

    public void setSpeed(float speed)
    {
        speedText.text = (speed * 100).ToString("F0");
        speedMat.SetFloat("_Fillpercentage", speed / 50);
    }
    public void decreaseSpeed(float speed)
    {

        speed = (speed - 0.00001f) * Time.deltaTime;
        speedText.text = (speed * 100).ToString("F0");
        speedMat.SetFloat("_Fillpercentage", speed / 50);
    }
    public void State(bool state)
    {
        this.state = state;
    }
}
