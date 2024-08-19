using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public HeartManager heartManager;

    public float groundHeight;
    public float levelHeight;
    public float levelWidth;
    public float heightDiff;

    public GameObject platformPrefab;
    public GameObject obstaclePrefab;
    public GameObject dandelionPrefab;

    public int avgNumObstacles;
    public float dandelionProb;

    // Start is called before the first frame update
    void Start()
    {
        generatePlatforms();
    }

    void generatePlatforms() 
    {
        float currHeight = groundHeight + heightDiff;
        float levelLeft = -levelWidth/2;
        float levelRight = levelWidth/2;

        while (currHeight < levelHeight) {
            float currX = Random.Range(levelLeft, levelRight);
            Vector3 pos = new Vector3(currX, currHeight, 0);
            Instantiate(platformPrefab, pos, Quaternion.identity);

            makeObstacles(pos);
            makeDandelion(pos);

            currHeight += heightDiff;
        }
        //makes a final platform at the height "levelHeight"
        float finalX = Random.Range(levelLeft, levelRight);
        Vector3 finalPos = new Vector3(finalX, levelHeight,0);
        Instantiate(platformPrefab, finalPos, Quaternion.identity);
    }

    void makeObstacles(Vector3 platformPos) 
    {
        int numObstacles = Random.Range(avgNumObstacles-2, avgNumObstacles+2);

        Vector2 platformSize = platformPrefab.GetComponent<BoxCollider2D>().size;
        float platformWidth = platformSize.x;
        float platformHeight = platformSize.y;

        Vector2 obstacleSize = obstaclePrefab.GetComponent<BoxCollider2D>().size;
        float obstacleWidth = obstacleSize.x;
        float obstacleHeight = obstacleSize.y;

        float obstacleY = platformPos.y - platformHeight/2 - obstacleHeight/2;

        for (int i = 0; i < numObstacles; i++) {
            float obstacleX = Random.Range(platformPos.x - platformWidth/2 + obstacleWidth/2,
                                           platformPos.x + platformWidth/2 - obstacleWidth/2);
            Vector3 obstaclePos = new Vector3(obstacleX, obstacleY, 0);
            GameObject obstacle = (GameObject)Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
            FallingObstacle script = obstacle.GetComponent<FallingObstacle>();
            script.heartManager = heartManager;
        }
    }

    void makeDandelion(Vector3 platformPos) {
        bool makeDandelion = Random.Range(0f, 1f) <= dandelionProb;

        if (makeDandelion) {
            float platformHeight = platformPrefab.GetComponent<BoxCollider2D>().size.y;
            float dandelionHeight = dandelionPrefab.GetComponent<BoxCollider2D>().size.y;

            float dandelionY = platformPos.y + platformHeight/2 + dandelionHeight/2;
            Vector3 dandelionPos = new Vector3(platformPos.x, dandelionY, 0);
            Instantiate(dandelionPrefab, dandelionPos, Quaternion.identity);
        }
    }

}