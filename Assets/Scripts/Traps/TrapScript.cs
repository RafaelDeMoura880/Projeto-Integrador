﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : Enemies
{
    bool isBouncing = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float hit = 100f;
            PlayerScript.instance.playerRb.AddForce(collision.contacts[0].normal * hit);
            isBouncing = true;
            Dano(30);
            Invoke("StopBouncing", 0.4f);
        }
    }

    void StopBouncing()
    {
        isBouncing = false;
    }
}
