using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Feet")
        {
            collision.GetComponentInParent<PlayerScript>().hasJumped = false;
            collision.GetComponentInParent<PlayerScript>().playerAnim.SetBool("isJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Feet")
        {
            collision.GetComponentInParent<PlayerScript>().hasJumped = true;
            collision.GetComponentInParent<PlayerScript>().playerAnim.SetBool("isJumping", true);
        }
    }
}
