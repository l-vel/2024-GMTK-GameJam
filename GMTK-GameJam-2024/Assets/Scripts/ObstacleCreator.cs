using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public float groundHeight;
    public float levelHeight;
    public float levelWidth;
    public float heightDiff;

    public GameObject platformPrefab;
    public GameObject obstaclePrefab;

    public int avgNumObstacles;

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
            currHeight += heightDiff;
        }
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
            Instantiate(obstaclePrefab, obstaclePos, Quaternion.identity);
        }
    }

