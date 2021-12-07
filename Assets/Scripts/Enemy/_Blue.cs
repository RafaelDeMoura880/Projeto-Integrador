using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Blue : Enemies
{
    BoxCollider2D playerTrigger;
    float playerTriggerSize;
    Animator enemyBlueAnim;
    Rigidbody2D enemyBlueRb;

    bool turnedLeft = true;
    
    public override void Start()
    {
        enemyMovement = 5f;
        enemySpeed = 5f;

        playerTrigger = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
        playerTriggerSize = this.transform.GetChild(0).GetComponent<BoxCollider2D>().size.x;

        enemyBlueAnim = GetComponent<Animator>();
        enemyBlueRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyBlueAnim.SetBool("isOnTrigger", true);
            //enemyBlueRb.velocity = new Vector2(enemyMovement * -1,)
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyBlueAnim.SetBool("isOnTrigger", false);
        }
    }

    void Flip()
    {
        turnedLeft = !turnedLeft;

        Vector3 auxScale = this.transform.localScale;
        auxScale.x *= -1;

        this.transform.localScale = auxScale;
    }
}
