using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public HeartManager heartManager;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            heartManager.respawnPoint = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
