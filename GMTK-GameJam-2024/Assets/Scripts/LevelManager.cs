using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public GameObject finishLevelPrefab;
    public ObstacleCreator obstacleCreator;
    private Vector3 levelHeight;
    // Start is called before the first frame update
    void Start()
    {
        spawnFinishPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void spawnFinishPoint()
    {
        levelHeight = new Vector3(0,obstacleCreator.levelHeight,0);
        Instantiate(finishLevelPrefab, levelHeight, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish" )
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
