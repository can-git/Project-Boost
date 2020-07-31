using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] ParticleSystem mainEngineParticles = null;
    [SerializeField] ParticleSystem successParticles = null;
    [SerializeField] ParticleSystem deathParticles = null;
    [SerializeField] ParticleSystem fireParticles = null;
    [SerializeField] ParticleSystem airParticles = null;
    [SerializeField] ParticleSystem airParticlesR = null;

    [SerializeField] Light engineLight = null;

    [SerializeField] float rcsTrust = 100f;
    [SerializeField] float mainTrust = 100f;

    enum State { Flying, Dying, Rescuing, Ascending };
    State state = State.Flying;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.Ascending)
        {
            if (state != State.Dying)
            {
                RespondToThrustInput();
                RespondToRotateInput();
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == State.Dying) { return; } // ignore collisions when dead

        switch (collision.gameObject.tag)
        {
            case "LaunchP":
                StartSuccessSequence();
                break;
            case "FuelP":

                break;
            case "Rocket":
                break;
            case "Alien":
                StartRescueSequences(collision);
                break;
            default:
                StartDeathSequences();
                break;
        }

    }


    private void StartDeathSequences()
    {
        mainEngineParticles.Stop();
        deathParticles.Play();
        fireParticles.Play();
        state = State.Dying;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        Invoke("LevelRestart", levelLoadDelay);
    }

    private void StartRescueSequences(Collision coll)
    {
        state = State.Rescuing;
        FindObjectOfType<AlienController>().deleteCount();
        Destroy(coll.gameObject);
    }
   
    private void StartSuccessSequence()
    {
        if (FindObjectOfType<AlienController>().getCount() <= 0)
        {
            if (transform.rotation.z >= -0.1 && transform.rotation.z <= .1)
            {
                state = State.Ascending;
                successParticles.Play();
                audioSource.Stop();
                audioSource.PlayOneShot(success);
                Invoke("LevelRestart", levelLoadDelay);
            }
        }
    }
    public void stateFlying()
    {
        state = State.Flying;
    }
    public void stateDying()
    {
        state = State.Dying;
    }
    public void stateRescue()
    {
        state = State.Rescuing;
    }


    private void NewRocket()
    {
        FindObjectOfType<RocketSpawner>().newRocket();
    }

    private void LevelRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            airParticlesR.Play();
            transform.Rotate(Vector3.forward * Time.deltaTime * rcsTrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            airParticles.Play();
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
            mainEngineParticles.Stop();
            engineLight.intensity = 2f;
        }
    }

    private void ApplyThrust()
    {
        engineLight.intensity = 10f;
        rigidBody.AddRelativeForce(Vector3.up * mainTrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        mainEngineParticles.Play();

    }
    private void RespondToTheEnding()
    {

    }
}
