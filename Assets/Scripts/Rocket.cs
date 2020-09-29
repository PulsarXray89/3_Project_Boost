using System;
using UnityEngine;
public class Rocket : MonoBehaviour
{
    [SerializeField] float mainThrust = 300f;
    [SerializeField] float rcsThrust = 100f;

    [SerializeField] AudioClip mainEngineAudio;
    [SerializeField] ParticleSystem mainEngineParticles;

    [SerializeField] bool isTranscending = false;

    Rigidbody rigidBody;
    AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(!isTranscending)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }

        if(isTranscending)
        {
            mainEngineParticles.Stop();
            audioSource.Stop();
        }

        //if (Debug.isDebugBuild)
        //{
        //    RespondToDebugKeys();
        //}
    }
    //private void RespondToDebugKeys()
    //{
    //    if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        LoadNextLevel();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        collisionsDisabled = !collisionsDisabled;
    //    }
    //}
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
        }
    }
    private void ApplyThrust()
    {
        float thrustSpeed = mainThrust * Time.deltaTime;
        rigidBody.AddRelativeForce(Vector3.up * thrustSpeed);
        if (!mainEngineParticles.isPlaying) { mainEngineParticles.Play(); }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineAudio);
        }
    }
    private void RespondToRotateInput()
    {
        float rotationSpeed = rcsThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        }
    }
    private void EnablePlayerTranscending() // referenced by string
    {
        isTranscending = true;
    }
}
