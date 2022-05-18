using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : Collectibles
{
    [SerializeField] int keyValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && PlayerScript.instance.Money >= keyValue)
        {
            PlayerScript.instance.keyAmount += 1;
            PlayerScript.instance.Money -= keyValue;
            PlayerScript.instance.gameSounds.PlayOneShot(PlayerScript.instance.keySound);
            Destroy(this.gameObject);
        }
    }
}
