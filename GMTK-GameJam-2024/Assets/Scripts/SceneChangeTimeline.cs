using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeTimeline : MonoBehaviour
{
    private float time;
    private float totalTime = 9;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(time < totalTime)
        {
            time += Time.deltaTime;
        }
        else if(time >= totalTime)
        {
            LoadScene();
            
        }
        
    }

    public void LoadScene()
    {
        
         SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}