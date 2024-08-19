using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    private int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish" )
        {
            SceneManager.LoadScene(sceneIndex);
            sceneIndex++;
        }
    }
}
