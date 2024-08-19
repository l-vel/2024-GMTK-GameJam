using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartManager : MonoBehaviour
{
    public GameObject gameOverUIPrefab;

    List<GameObject> hearts = new List<GameObject>();
    int numHeartsActive;

    public Vector3 respawnPoint;

    const int MAX_NUM_HEARTS = 3;

    // Start is called before the first frame update
    void Start()
    {
        hearts.Add(GameObject.Find("Heart (1)"));
        hearts.Add(GameObject.Find("Heart (2)"));
        hearts.Add(GameObject.Find("Heart (3)"));

        numHeartsActive = 3;
    }

    public void removeHeart(Collision2D goat) {
        if (numHeartsActive > 0) {
            hearts[--numHeartsActive].SetActive(false);
        }

        if (numHeartsActive == 0) {
            gameOver(goat.gameObject);
        }
    }

    public void addHeart() {
        if (numHeartsActive < MAX_NUM_HEARTS) {
            hearts[numHeartsActive++].SetActive(true);
        }
    }

    public void gameOver(GameObject goat) {
        if (respawnPoint == null) {
            Destroy(goat);
            Instantiate(gameOverUIPrefab);
        }
        else {
            goat.transform.position = respawnPoint;
            addHeart();
        }
    }
}
