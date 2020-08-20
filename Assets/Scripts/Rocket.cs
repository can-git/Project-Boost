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

    [SerializeField] GameObject LPlatform = null;

    [SerializeField] bool canDie = true;

    [SerializeField] float rcsTrust = 100f;
    [SerializeField] float mainTrust = 100f;

    enum State { Finished,NotFinished};
    State state = State.NotFinished;

    float lastPos;
    float velocity;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        StartCoroutine(CalcVelocity());
        if (state == State.NotFinished)
        {
            FindObjectOfType<Pointer>().setVelocity(velocity);
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == State.Finished) { return; } // ignore collisions when dead
        if (canDie == false) { return; }
        if (velocity <= -10)
        {
            StartDeathSequences();
        }
        else
        {
            switch (collision.gameObject.tag)
            {
                case "LaunchP":
                    StartSuccessSequence();
                    break;
                case "Friendly":
                    break;
                default:
                    StartDeathSequences();
                    break;
            }
        }
    }

    private void StartDeathSequences()
    {
        if (canDie)
        {
            mainEngineParticles.Stop();
            deathParticles.Play();
            fireParticles.Play();
            state = State.Finished;
            audioSource.Stop();
            audioSource.PlayOneShot(death);
            Invoke("LevelRestart", levelLoadDelay);
        }
    }
    private void StartSuccessSequence()
    {
        if (FindObjectOfType<AlienController>().getCount() <= 0)
        {
            if (transform.rotation.z >= -0.1 && transform.rotation.z <= .1)
            {
                canDie = false;
                state = State.Finished;
                successParticles.Play();
                audioSource.Stop();
                audioSource.PlayOneShot(success);
                Invoke("LoadNextLevel", levelLoadDelay);
            }
        }
    }
    private void LevelRestart()
    {
        FindObjectOfType<LevelController>().LevelRestart();
    }
    private void LoadNextLevel()
    {
        FindObjectOfType<LevelController>().LevelLoad(SceneManager.GetActiveScene().buildIndex+1);
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
            if (FindObjectOfType<OilController>().GetValue() > 0)
            {

                FindObjectOfType<OilController>().SpendOil();
                engineLight.intensity = 10f;
                rigidBody.AddRelativeForce(Vector3.up * mainTrust * Time.deltaTime);
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(mainEngine);
                }
                mainEngineParticles.Play();
            }
        }
        else
        {
            audioSource.Stop();
            mainEngineParticles.Stop();
            engineLight.intensity = 2f;
        }
    }



    IEnumerator CalcVelocity()
    {
        lastPos = this.transform.position.y;
        yield return new WaitForFixedUpdate();
        velocity = (this.transform.position.y - lastPos) / Time.fixedDeltaTime;
    }
}
