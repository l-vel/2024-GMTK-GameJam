using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public HeartManager heartManager;

    public bool isGrounded = false;
    public float horizontalSpeed;
    public float verticalAcceleration;

    float jumpBoostTimePassed = 0;
    float regularJump;
    float jumpBoostDur = 0;

    Rigidbody2D rb;
    AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        regularJump = verticalAcceleration;

        jumpSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();

        checkJumpBoost();
        checkOffScreen();
    }

    void HorizontalMovement()
    {
        Vector3 pos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos += Vector3.left * horizontalSpeed;
            gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            if (isGrounded) {
                animator.Play("Walk");
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pos += Vector3.right * horizontalSpeed;
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            if (isGrounded) {
                animator.Play("Walk");
            }
        }

        if (isGrounded && (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))) {
            animator.Play("Idle");
        }

        gameObject.transform.position = pos;
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && rb.velocity == new Vector2(0, 0))
        {
            jumpSound.Play();
            animator.Play("Jump");
            rb.AddForce(new Vector2(0, verticalAcceleration), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (rb.velocity == new Vector2(0, 0)) {
                if (isGrounded == false) {
                    animator.Play("Idle");
                }

                isGrounded = true;
            } 
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    public void jumpBoost(float jumpScale, float duration) {
        jumpBoostDur += duration;

        if (jumpBoostTimePassed == 0) {
            verticalAcceleration *= jumpScale;
        }
    }

    void checkJumpBoost() {
        if (jumpBoostDur != 0) {        // if there is a jump boost active
            jumpBoostTimePassed += Time.deltaTime;

            if (jumpBoostTimePassed >= jumpBoostDur) {
                verticalAcceleration = regularJump;
                jumpBoostTimePassed = 0;
                jumpBoostDur = 0;
            }
        }
    }

    void checkOffScreen() {
        if (gameObject.transform.position.y < -15) {
            heartManager.gameOver(gameObject);
        }
    }
}
