using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;
    public float horizontalSpeed;
    public float verticalAcceleration;

    Rigidbody2D rb;
    AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();
    }

    void HorizontalMovement()
    {
        Vector3 pos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos += Vector3.left * horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pos += Vector3.right * horizontalSpeed;
        }

        gameObject.transform.position = pos;
    }

    void Jump()
    {
        
        if (Input.GetKey(KeyCode.Space) && isGrounded && rb.velocity == new Vector2(0, 0))
        {
            jumpSound.Play();
            rb.AddForce(new Vector2(0, verticalAcceleration), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}
