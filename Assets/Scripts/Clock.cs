using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour {

	public Material speedMat;
	public Material oilMat;
	public TextMesh speedText;
	public TextMesh minuteText;

	void Start () {
		//GameObject.Find("BG").SetActive(false);
		setSpeed(0);
		setOil(0);
	}
	
	// Update is called once per frame 
	void FixedUpdate () {

	}

	public void setOil (float oilValue) {
		minuteText.text = oilValue.ToString("F2");
		oilMat.SetFloat("_Fillpercentage", oilValue);
	}

	public void setSpeed(float speed) {
		speedText.text = (speed*100).ToString("F0");
		speedMat.SetFloat("_Fillpercentage",speed/50);
	}
	public void decreaseSpeed(float speed)
    {
		
		speed = (speed - 0.001f) * Time.deltaTime;
		speedText.text = (speed * 100).ToString("F0");
		speedMat.SetFloat("_Fillpercentage", speed / 50);
    }
}
