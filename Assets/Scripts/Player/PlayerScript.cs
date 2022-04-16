using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D playerRb;
    Collider2D playerCollider;
    BoxCollider2D playerFeet;
    public AudioSource gameSounds;
    public AudioSource soundtrack;
    public AudioClip pickUpSound;
    public AudioClip lockSoundTrimmed;
    public Animator playerAnim;

    public Vector2 playerLocation;

    [SerializeField] int score = 0;
    [SerializeField] int energy = 100;
    public static int Hearts = 3;
    public int levers = 0;

    float playerMovement;
    [SerializeField] float playerSpeed = 1;
    [SerializeField] float playerJumpForce = 1;

    bool turnedRight = true;
    public bool hasJumped;
    public bool hasKey = false;

    public static PlayerScript instance;

    public int Money
    {
        get => score;
        set => score = value;
    }

    public int Life
    {
        get => energy;
        set => energy = value;
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnim = GetComponent<Animator>();
        playerFeet = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
        gameSounds = this.gameObject.GetComponent<AudioSource>();
        soundtrack = GameObject.Find("Cameras").transform.GetChild(0).GetComponent<AudioSource>();
        soundtrack.Play();

        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Endgame")
        {
            MenuScript.terminouText = "Vitória";
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();

        if (hasJumped)
            PlayerJump();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            hasJumped = true;

        ClimbLadder();

        playerLocation = this.transform.position;
    }

    //..

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

    void ClimbLadder()
    {
        if(!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) { return; }

        float playerClimbing = Input.GetAxis("Vertical");
        playerRb.velocity = new Vector2(playerRb.velocity.x, playerClimbing * playerSpeed);
    }
}
