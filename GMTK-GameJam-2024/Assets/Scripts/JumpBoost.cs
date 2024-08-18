using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float duration;
    public float jumpScale;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.jumpBoost(jumpScale, duration);
            Destroy(gameObject);
        }
    }
}
