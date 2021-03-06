﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    
    float cycles;
    const float tau = Mathf.PI * 2;
    float rawSinWave;

    float movementFactor; // 0 for not moved, 1 for fully moved.

    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        cycles = Time.time / period; // grows continually from 0
        rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;

    }
}
