using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Must use UI engine
using UnityEngine.SceneManagement; // Must use Scene Management 
using LootLocker.Requests;

public class UIScript : MonoBehaviour
{
    public Health health;
    public PauseResume pauseResume;
    public GameOverScript gameOverScript;
    public ScoreDisplayScript gameOverlayScript;
    public PowerProgressbar powerProgressbar;
    public HealthV2 healthv2;

    public Text ErrorMessage;
    public Text SubmitIndicatorFalse;
    public Text SubmitIndicatorTrue;
    public Text AlreadySubmittedScore;
    public Text NameTooLong;

    public Text TimeUntilSeasonEnds;

    bool rasoR = false;
    bool rasoA = false;
    bool rasoS = false;
    bool rasoO = false;

    // Leaderboard stuff
    public InputField MemberID;
    public int ID;

    bool hasSubmittedScore;

    void Start()
    {
        // Starts LootLocker guest session
        
        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {

            if (response.success)
            {
                Debug.Log("Succesfully started guest session;");

            }
            else
            {
                Debug.Log("Failed to start guest session");
            }

        });
        

        hasSubmittedScore = false;
    }


    //Game Over Screen
    void Update()
    {
        /*
        try
        {
            SeasonTimer();
        }
        catch { }
        */
        try
        // Some objects that use this script are not given referances to other scripts (b/c they dont need them)
        // This raises an error, so caught is used to stop the error
        // (This is a terrible fix and I should properly reorganize the scripts, but im lazy)
        {
            if (healthv2.currentHealth <= 0)
            {
                gameOverScript.GameOver();
                gameOverlayScript.HideScoreDisplay();
                powerProgressbar.HideShockWaveBarOverlay();
                healthv2.HideHealthRingOverlay();
                pauseResume.HidePauseResumeOverlay();

            }
        }
        catch
        {
            // Do nothing
        }

        if (rasoO)
        {
            SceneManager.LoadScene("Raso");
            rasoR = false;
            rasoA = false;
            rasoS = false;
            rasoO = false;
        }
    }
    //Game Over Screen
    public void PlayAgainButton()
    {
        Score.scoreValue = 0;
        SceneManager.LoadScene("Game");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void R()
    {
        rasoR = true;
    }
    public void A()
    {
        if (rasoR)
        {
            rasoA = true;
        }

    }
    public void S()
    {
        if (rasoA)
        {
            rasoS = true;
        }
    }
    public void O()
    {
        if (rasoS)
        {
            rasoO = true;
        }
    }
    public void SeasonTimer()
    {
        DateTime seasonEnd = new DateTime(2022, 05, 19); 
        var timeLeftInSeason  = seasonEnd - System.DateTime.Now;

        TimeUntilSeasonEnds.text = timeLeftInSeason.ToString();
    }
    public void SubmitScore()
    {
        /* Sets the player score to the game score
         * 
         * Checks if name is ecniv, this sets the member ID to Vince__ which and another script uses
         * this to grant me a red name
         * 
         * If a name length isnt 7 characters underscores are added to it so that is equals 7 characters
         * this is for score formatting
         * 
         * Error checks
         * 
         * If a name is valid the score will be submitted, and "success" will be displayed, if this fails
         * "failed" will be displayed
         */

        int PlayerScore = Score.scoreValue;
        bool validSubmission = true;

        if (MemberID.text == "ecniv")
        {
            MemberID.text = "VinCE__";
        }

        switch (MemberID.text.Length)
        {
            case 1:
                MemberID.text += "______";
                break;
            case 2:
                MemberID.text += "_____";
                break;
            case 3:
                MemberID.text += "____";
                break;
            case 4:
                MemberID.text += "___";
                break;
            case 5:
                MemberID.text += "__";
                break;
            case 6:
                MemberID.text += "_";
                break;
        }

        // ERROR CHECKING

        if (MemberID.text == "")
        // No name entered
        {
            validSubmission = false;
            ErrorMessage.text = "Must enter a name";
            ErrorMessage.color = Color.red;
            ErrorMessage.gameObject.SetActive(true);
        }

        if (MemberID.text.Length > 7)
        // Name too long
        {
            validSubmission = false;
            ErrorMessage.text = "Name Too Long";
            ErrorMessage.color = Color.red;
            ErrorMessage.gameObject.SetActive(true);
        }

        else if (hasSubmittedScore)
        // Has already submitted their score
        {
            validSubmission = false;
            ErrorMessage.text = "Already Submitted Score";
            ErrorMessage.color = new Color(0f / 255f, 100f / 255f, 0f / 255f);
            ErrorMessage.gameObject.SetActive(true);
        }

        if (validSubmission)
        { 
            LootLockerSDKManager.SubmitScore(MemberID.text, PlayerScore, ID, (response) =>
            {
                if (response.success)
                {
                    //Debug.Log("Succesfully submited scores");
                    ErrorMessage.text = "Success";
                    ErrorMessage.color = new Color(0f/255f, 100f/255f, 0f/255f);
                    ErrorMessage.gameObject.SetActive(true);

                    hasSubmittedScore = true;
                }

                else
                {
                    //Debug.Log("Failed to submit score");
                    ErrorMessage.text = "Failed";
                    ErrorMessage.color = Color.red;
                    ErrorMessage.gameObject.SetActive(true);

                }

            });
            ErrorMessage.text = "";
            ErrorMessage.gameObject.SetActive(false);
        }

    }
}
