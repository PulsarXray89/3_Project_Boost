using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    [SerializeField] GameObject onPickupParticles;
    [SerializeField] int points = 5;

    ScoreText scoreText;

    private void Start()
    {
        scoreText = FindObjectOfType<ScoreText>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Instantiate(onPickupParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreText.AddToScore(points);
        }
    }
}
