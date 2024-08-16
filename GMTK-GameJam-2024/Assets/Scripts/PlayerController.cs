using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded = false;
    public float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            pos += Vector3.left*horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            pos += Vector3.right*horizontalSpeed;
        }
        gameObject.transform.position = pos;
    }
}
