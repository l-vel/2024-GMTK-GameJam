using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    public float distance;
    bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;

        if (!isFalling)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance);
            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            // makes obstacle fall on player after player passes by
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    rb.gravityScale = 5;
                    isFalling = true;
                }
            }
        }
    }

    // removes obstacle after it touches player
    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        else
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }
}
