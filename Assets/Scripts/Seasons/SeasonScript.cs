using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeasonScript : MonoBehaviour
{
    public Text TimeUntilSeasonEnds;
 

    void Update()
    {
        try
        {
            SeasonTimer();
        }
        catch { }
    }
    public void SeasonTimer()
    {
        //DateTime seasonEnd = new DateTime(2022, 05, 19);
        DateTime seasonEnd = new DateTime(2022, 05, 26);
        var timeLeftInSeason = seasonEnd - System.DateTime.Now;

        int seconds = timeLeftInSeason.Seconds;
        int minutes = timeLeftInSeason.Minutes;
        int hours = timeLeftInSeason.Hours;
        int days = timeLeftInSeason.Days;

        TimeUntilSeasonEnds.text = days.ToString() + " : " + hours.ToString() + " : " + minutes.ToString() + " : " + seconds.ToString();

        if (days+hours+minutes+seconds <= 0)
        {
            TimeUntilSeasonEnds.color = Color.red;
            TimeUntilSeasonEnds.text = "Season Over";
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
