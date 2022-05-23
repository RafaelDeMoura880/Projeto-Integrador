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
    public AudioClip trapSound;
    public AudioClip keySound;

    public Animator playerAnim;

    public Vector2 playerStartLocation;
    public static Vector2 playerCheckpointLocation;
    public Vector2 playerLocation;

    [SerializeField] int score = 0;
    [SerializeField] int energy = 100;
    public static int Hearts = 3;
    public int levers = 0;
    public int keyAmount = 0;

    float playerMovement;
    float gravityScaleAtStart;
    [SerializeField] float playerSpeed = 1;
    [SerializeField] float playerJumpForce = 1;

    bool turnedRight = true;
    public bool isOnCheckpoint = false;
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
        gravityScaleAtStart = playerRb.gravityScale;
        playerCollider = GetComponent<Collider2D>();
        playerAnim = GetComponent<Animator>();
        playerFeet = this.transform.GetChild(0).GetComponent<BoxCollider2D>();
        gameSounds = this.gameObject.GetComponent<AudioSource>();
        soundtrack = GameObject.Find("Cameras").transform.GetChild(0).GetComponent<AudioSource>();
        soundtrack.Play();
        playerStartLocation = this.transform.position;

        instance = this;
    }

    private void FixedUpdate()
    {
        PlayerMovement();

        if (hasJumped)
            PlayerJump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossAnnouncement" || 
            collision.gameObject.tag == "BossAnnouncement")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            hasJumped = true;

        ClimbLadder();
        KeyCounter();

        if (levers == 3)
            StartCoroutine(Endgame());

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
        if(!playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            playerRb.gravityScale = gravityScaleAtStart;
            return; 
        }

        float playerClimbing = Input.GetAxis("Vertical");
        playerRb.velocity = new Vector2(playerRb.velocity.x, playerClimbing * playerSpeed);
        playerRb.gravityScale = 0f;
    }

    void KeyCounter()
    {
        if (keyAmount > 0)
        {
            hasKey = true;
            CanvasScript.instanceCanvas.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            hasKey = false;
            CanvasScript.instanceCanvas.gameObject.transform.GetChild(3).
                gameObject.SetActive(false);
        }

        if (keyAmount == 1)
            CanvasScript.instanceCanvas.gameObject.transform.GetChild(4).
                gameObject.SetActive(false);
        if (keyAmount == 2)
        {
            CanvasScript.instanceCanvas.gameObject.transform.GetChild(4).
                gameObject.SetActive(true);
            CanvasScript.instanceCanvas.gameObject.transform.GetChild(4).
                    transform.GetChild(1).gameObject.SetActive(false);
        }
        if (keyAmount == 3)
        {
            CanvasScript.instanceCanvas.gameObject.transform.GetChild(4).
                transform.GetChild(0).gameObject.SetActive(false);
            CanvasScript.instanceCanvas.gameObject.transform.GetChild(4).
                transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    
    IEnumerator Endgame()
    {
        yield return new WaitForSeconds(5f);
        MenuScript.terminouText = "Vitória";
        SceneManager.LoadScene(0);
    }
}
