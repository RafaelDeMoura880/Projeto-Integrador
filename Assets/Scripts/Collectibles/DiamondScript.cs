using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DiamondScript : Collectibles
{
    [SerializeField] int diamondValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerScript.instance.gameSounds.PlayOneShot(PlayerScript.instance.pickUpSound);
            AddScore(diamondValue);
        }
    }
}
