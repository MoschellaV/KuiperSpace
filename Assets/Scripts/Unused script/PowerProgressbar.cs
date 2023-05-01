using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class PowerProgressbar : MonoBehaviour
{
    public Image Fillbar;
    public GameObject ShockWaveReady;
    public Text powerUpText;

    public void GetCurrentFill(float arg1, float arg2)
        /* This method takes in two floats and divides them by eachother, 
         * then updates the Fillbar object.
         * 
         * From the player controller script we pass in elapsed time
         * and the power up cooldown variable. 
        */
    {
        float fillamount = arg1 / arg2;
        Fillbar.fillAmount = fillamount;

    }
    public void HideReady()
    {
        // Hides Ready Text
        ShockWaveReady.SetActive(false);
    }

    // ShockWave
    public void DisplayShockWaveReady()
    {
        // Changes the power up text and activates it
        powerUpText.text = "ShockWave Ready";
        ShockWaveReady.SetActive(true);
    }
    

    // Shield
    public void DisplayShieldReady()
    {
        // Changes the power up text and activates it
        powerUpText.text = "Shield Ready";
        ShockWaveReady.SetActive(true);
    }


    // Slow Time
    public void DisplaySlowTimeReady()
    {
        // Changes the power up text and activates it
        powerUpText.text = "SlowTime Ready";
        ShockWaveReady.SetActive(true);
    }

    public void HideShockWaveBarOverlay()
    {
        // Hides ShockWaveBar
        gameObject.SetActive(false);
    }
}
