using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float rcsTrust = 100f;
    [SerializeField] float mainTrust = 100f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "LaunchP":
                print("Launch Platform");
                break;
            case "FuelP":
                print("Fuel Platform");
                break;
            case "TargetP":
                print("Target Platform");
                break;
            default:
                print("You are dead");
                break;
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rcsTrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rcsTrust);
        }
        rigidBody.freezeRotation = false;
    }

    private void Thrust()
    {
        audioSource.volume = 0f;
        if (Input.GetKey(KeyCode.Space))
        {
            audioSource.volume = 1f;
            rigidBody.AddRelativeForce(Vector3.up * mainTrust);
        }
    }
}
