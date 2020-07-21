using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] AudioClip mainEngine = null;
    [SerializeField] AudioClip success = null;
    [SerializeField] AudioClip death = null;

    [SerializeField] float rcsTrust = 100f;
    [SerializeField] float mainTrust = 100f;

    enum State { Alive, Dying, Transcending};
    State state = State.Alive;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Alive)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(state != State.Alive){return;} // ignore collisions when dead

        switch (collision.gameObject.tag)
        {
            case "FriendlyP":

                break;
            case "TargetP":
                StartSuccessSequence();
                break;
            case "Rocket":

                break;

            default:
                StartDeathSequences();
                break;
        }
    }

    private void StartDeathSequences()
    {
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        Invoke("NewRocket", 2f);
    }

    private void StartSuccessSequence()
    {
        state = State.Transcending;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        //Invoke("LoadNextLevel", 2f);
    }

    private void NewRocket()
    {
        FindObjectOfType<RocketSpawner>().newRocket();
    }

    private static void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    private void RespondToRotateInput()
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

    private void RespondToThrustInput()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void ApplyThrust()
    {
        rigidBody.AddRelativeForce(Vector3.up * mainTrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }
}
