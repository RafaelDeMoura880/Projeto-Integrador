using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Blue : Enemies
{
    public Animator enemyBlueAnim;
    Rigidbody2D enemyBlueRb;
    BoxCollider2D enemyHead;
    bool turnedLeft = true;
    public bool ativo = false;
    
    public override void Start()
    {
        enemyMovement = 5f;
        enemySpeed = -5f;

        enemyBlueAnim = GetComponent<Animator>();
        enemyBlueRb = GetComponent<Rigidbody2D>();
        enemyHead = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (ativo)
            enemyBlueRb.velocity = new Vector2(enemySpeed, enemyBlueRb.velocity.y);
        else
            enemyBlueRb.velocity = new Vector2(0, enemyBlueRb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limites")
            Flip();
        if (collision.gameObject.tag == "Player")
            Dano(10);
    }

    public void Flip()
    {
        enemySpeed *= -1;
        turnedLeft = !turnedLeft;
        Vector3 auxScale = this.transform.localScale;
        auxScale.x *= -1;
        this.transform.localScale = auxScale;
    }
}
