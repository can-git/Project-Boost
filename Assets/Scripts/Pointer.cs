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
}
