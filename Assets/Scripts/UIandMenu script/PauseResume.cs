using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResume : MonoBehaviour
{
    public Sprite resumeButton;
    public Sprite pauseButton;
    public Button button;
    
    bool isResumed = true;
    
    public void ChangeButton()
    {
        // Changes the icon of the pause/resume button

        if (isResumed)
        {
            button.image.sprite = pauseButton;
            isResumed = false;
            PauseGame();
        }
        else
        {
            button.image.sprite = resumeButton;
            isResumed = true;
            ResumeGame();
        }
    }
    public void PauseGame()
    {
        // stops most operations of the gaame
        Time.timeScale = 0; 
    }
    public void ResumeGame()
    {
        //resumes all stopped operations
        Time.timeScale = 1;
    }
    public void HidePauseResumeOverlay()
    {
        // Hides the object this script is attached to
        gameObject.SetActive(false);
    }
}
