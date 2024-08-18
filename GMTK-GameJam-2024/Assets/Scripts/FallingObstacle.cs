using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingObstacle : MonoBehaviour
{
    public HeartManager heartManager;

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

            // makes obstacle fall to ground after player passes by
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    rb.gravityScale = 2;
                    isFalling = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if object touches player, removes player and restarts the game level after a couple seconds
        if (collision.gameObject.CompareTag("Player"))
        {
            heartManager.removeHeart(collision);
            Destroy(gameObject);
        }

        // otherwise, the obstacle remains on the ground
        // else
        // {
        //     rb.gravityScale = 0;
        // }
    }
}
