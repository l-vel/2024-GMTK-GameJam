using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    TMP_Text text;
    public float secsTillStart;
    float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    { 
        text = GetComponent<TMP_Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= secsTillStart) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + Time.deltaTime/2);
        }
    }
}
