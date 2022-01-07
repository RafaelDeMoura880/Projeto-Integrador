using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinScript : Collectibles
{
    [SerializeField] int coinValue = 1;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerScript.instance.gameSounds.PlayOneShot(PlayerScript.instance.pickUpSound);
            AddScore(coinValue);
        }
    }
}
