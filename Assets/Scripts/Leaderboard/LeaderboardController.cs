using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine.SceneManagement;

public class LeaderboardController : MonoBehaviour
{
    public int ID;
    int MaxScores = 7;
    public Text[] Entries;

    void Start()
    {
        /* Starts a guest session in LootLocker
         * then displays if the session start failed or was a success
         */
        
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
        
    }
    public void ShowScores()
    {
        /* Gets the score list from the LootLocker. Iterates through the list assigning each element
         * to a unity text UI element. These text elements are then displayed on the leaderboard in order.
         * If there are not enough scores to fill the leaderboard "none" will fill any voids.
         * 
         * Also checks if a name is "Vince" and makes the text red. (I added this b/c I can)                         
         * 
         */
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + "           " + scores[i].member_id + "       " + scores[i].score);

                    if (scores[i].member_id == "VinCE__")
                    {
                        var x = Entries[i].GetComponent<Text>();
                        x.color = Color.red;
                      
                    }
                }

                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + "           none";
                    }
                }
            }

            else
            {
                Debug.Log("Failed to Load Scores");
            }

        });
    }
    public void MenuButton()
    {
        // Loads main menu

        SceneManager.LoadScene("MainMenu");
    }
}
