﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPlatform : MonoBehaviour
{

    [SerializeField] Rocket rocket;

    void Start()
    {
        Instantiate(rocket,
            new Vector3(
                this.transform.position.x,
                this.transform.position.y + 2,
                this.transform.position.z
                ),
            Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}