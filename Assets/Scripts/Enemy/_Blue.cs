using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Blue : Enemies
{
    BoxCollider2D playerTrigger;
    Animator enemyBlueAnim;
    
    public override void Start()
    {
        enemyMovement = 5f;
        enemySpeed = 5f;

        playerTrigger = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
        enemyBlueAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyBlueAnim.SetBool("isOnTrigger", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyBlueAnim.SetBool("isOnTrigger", false);
        }
    }
}
