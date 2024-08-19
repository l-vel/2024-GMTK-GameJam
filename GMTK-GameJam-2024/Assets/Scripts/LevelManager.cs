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
        SpawnFinishPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnFinishPoint()
    {
        levelHeight = new Vector3(0,obstacleCreator.levelHeight + 2,0);
        Instantiate(finishLevelPrefab, levelHeight, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish" )
        {

           Invoke("LoadScene", 1);
            
        }
    }

    private void LoadScene()
    {
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
