﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnim;
    BoxCollider2D playerFeet;

    [SerializeField] int score = 0;

    float playerMovement;
    [SerializeField] float playerSpeed = 1;
    [SerializeField] float playerJumpForce = 1;

    bool turnedRight = true;
    [SerializeField] bool hasJumped;

    public int Money
    {
        get => score;
        set => score = value;
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerFeet = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();

        if (hasJumped)
            PlayerJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Scenario")
        {
            hasJumped = false;
            playerAnim.SetBool("isJumping", false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            hasJumped = true;
    }

    void PlayerMovement()
    {
        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);
        playerMovement = Input.GetAxis("Horizontal");

        if ((pos.x > 0 && playerMovement < 0) || (pos.x < 1 && playerMovement > 0))
            playerMovement *= playerSpeed;
        else
            playerMovement = 0f;

        if ((playerMovement > 0 && !turnedRight) || (playerMovement < 0 && turnedRight))
            Flip();

        if (playerMovement != 0)
            playerAnim.SetBool("isRunning", true);
        else
            playerAnim.SetBool("isRunning", false);

        playerRb.velocity = new Vector2(playerMovement, playerRb.velocity.y);
    }

    void Flip()
    {
        turnedRight = !turnedRight;

        Vector3 auxScale = this.transform.localScale;
        auxScale.x *= -1;
        this.transform.localScale = auxScale;
    }

    void PlayerJump()
    {
        if (!playerFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        playerRb.AddForce(new Vector2(0f, playerJumpForce), ForceMode2D.Impulse);
        playerAnim.SetBool("isJumping", true);
    }
}
