using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Loads the game and sets the score to 0
        Score.scoreValue = 0;
        SceneManager.LoadScene("Game");
    }
    public void Controls()
    {
        // Loads controls
        SceneManager.LoadScene("Controls");
    }
    public void PlayerSelect()
    {
        // Loads character select
        SceneManager.LoadScene("CharacterSelect");
    }
    public void Leaderboard()
    {
        // Loads Leaderboard
        SceneManager.LoadScene("Leaderboard");
    }
    public void Seasons()
    {
        // Loads Leaderboard
        SceneManager.LoadScene("Seasons");
    }
}
