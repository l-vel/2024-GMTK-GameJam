using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public float groundHeight;
    public float levelHeight;
    public float levelWidth;
    public float heightDiff;

    public float dandelionProb;
    public float dandelionHeightDiff;
    
    public GameObject platformPrefab;
    public GameObject dandelionPrefab;

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

            makeDandelion(pos);

            currHeight += heightDiff;
        }
    }

    void makeDandelion(Vector3 platformPos) {
        float isDandelion = Random.Range(0f, 1f);

        if (isDandelion <= dandelionProb) {
            Vector3 dandelionPos = platformPos + Vector3.up*dandelionHeightDiff;
            Instantiate(dandelionPrefab, dandelionPos, Quaternion.identity);
        }
    }
}
