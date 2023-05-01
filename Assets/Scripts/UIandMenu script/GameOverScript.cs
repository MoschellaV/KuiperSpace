using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;  //  public variable that will take a text UI element 

    public void GameOver()
    {
        gameObject.SetActive(true); // Activates the game over screen so it is visible to the player
                                   
        pointsText.text = " Score " + Score.scoreValue;  // Displays the points by utilizing the score value from the score script

    }
}
