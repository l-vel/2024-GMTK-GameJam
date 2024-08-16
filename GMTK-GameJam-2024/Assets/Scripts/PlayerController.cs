using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded = true;
    public float horizontalSpeed;
    public float verticalAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();
    }

    void HorizontalMovement() {
        Vector3 pos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            pos += Vector3.left*horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            pos += Vector3.right*horizontalSpeed;
        }
        
        gameObject.transform.position = pos;
    }

    void Jump() {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            rb.AddForce(new Vector2(0, verticalAcceleration));
        }
    }
}
