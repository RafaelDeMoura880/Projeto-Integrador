using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("activateLever");
            PlayerScript.instance.levers += 1;
        }
    }
}
