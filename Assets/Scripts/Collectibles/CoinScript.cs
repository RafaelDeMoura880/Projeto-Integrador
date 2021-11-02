using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : Collectibles
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AddScore(1);
        }
    }
}
