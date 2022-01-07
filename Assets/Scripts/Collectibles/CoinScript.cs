using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinScript : Collectibles
{
    [SerializeField] int coinValue = 1;
    AudioSource coinSounds;
    [SerializeField] AudioClip coinPickUpSound;

    public override void Start()
    {
        base.Start();
        coinSounds = collectiblesSounds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            coinSounds.PlayOneShot(coinPickUpSound, 1);
            AddScore(coinValue);
        }
    }
}
