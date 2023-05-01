using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;  
    Text score; // text variable for score

    void Start()
    {
        score = GetComponent<Text>();  
    }
    void Update()
    {
        // Gives the score text object a value
        score.text = " Score " + scoreValue;

        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
             scoreValue += 200;
        }
        */
    }
}
