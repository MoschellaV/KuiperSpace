using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasterEggSC : MonoBehaviour
{
    public void Continue()
    {
        // Loads main menu
        SceneManager.LoadScene("MainMenu");
    }
}
