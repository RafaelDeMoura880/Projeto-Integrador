using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : Enemies
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Dano(30);
            PlayerScript.instance.gameSounds.PlayOneShot(PlayerScript.instance.trapSound, 3);
        }
    }
}
