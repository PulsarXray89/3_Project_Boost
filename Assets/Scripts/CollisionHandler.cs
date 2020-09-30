using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    

    [SerializeField] GameObject deathParticles;
    [SerializeField] GameObject successParticles;
    GameObject landingPad;

    float levelLoadDelay = 2f;
    SceneLoader loader;
    bool isCollisionsDisabled = false;

    private void Start()
    {
        loader = FindObjectOfType<SceneLoader>().GetComponent<SceneLoader>();
        landingPad = GameObject.FindGameObjectWithTag("Finish");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isCollisionsDisabled) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // Do nothing;
                break;
            case "Finish":
                StartFinishSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }
    private void StartFinishSequence()
    {
        isCollisionsDisabled = true;
        SendMessage("EnablePlayerTranscending");
        Instantiate(successParticles, landingPad.transform.position, Quaternion.identity);
        loader.Invoke("LoadNextLevel", levelLoadDelay);
    }
    private void StartDeathSequence()
    {
        isCollisionsDisabled = true;
        SendMessage("EnablePlayerTranscending");
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
        loader.Invoke("LoadFirstLevel", levelLoadDelay);
    }
}
