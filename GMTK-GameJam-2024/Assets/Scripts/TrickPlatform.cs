using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickPlatform : MonoBehaviour
{
    public float holdTime = 2f;
    public float currentTime = 0f;
    public bool startTime = false;

    void Update()
    {
        if (startTime)
        {
            currentTime += Time.deltaTime;

            if (currentTime > holdTime)
            {
                gameObject.SetActive(false);
                currentTime = 0f;
                startTime = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startTime = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startTime = false;
            currentTime = 0f;
        }
    }
}
