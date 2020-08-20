using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pointer : MonoBehaviour
{

    public Material velocityMat;
    public Material oilMat;
    public TextMesh velocityText;
    public TextMesh minuteText;

    public void setOil(float oilValue)
    {
        minuteText.text = oilValue.ToString("F2");
        oilMat.SetFloat("_Fillpercentage", oilValue);
    }

    public void setVelocity(float velocity)
    {
        velocityText.text = (velocity * 100).ToString("F0");
        velocityMat.SetFloat("_Fillpercentage", velocity / 50);
    }
}
