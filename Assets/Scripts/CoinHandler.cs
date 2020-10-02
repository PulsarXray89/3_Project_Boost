using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    [SerializeField] GameObject onPickupParticles;
    [SerializeField] int points = 5;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Instantiate(onPickupParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreText.instance.AddToScore(points);
        }
    }
}
