using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Must use unity's UI engine 

public class Health : MonoBehaviour
{
    //Calls to other files
    //public GameOverScript gameoverscript;
    //public PauseResume pauseResume;

    public int health;
    public int numberOfHearts;
    
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        /*
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        */
    }
    public void TakeDamage()
    // Removes health from the player
    {
        health -= 1;
         
    }
    

}
