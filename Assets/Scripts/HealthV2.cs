using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthV2 : MonoBehaviour
{
    public Text health;
    public Image FillRing;
    public float currentHealth = 100;

    void Update()
    {
        health.text = currentHealth + "%";
    }
    public void GetHealthFill(int DamageTaken)
    /* This method takes in two floats and divides them by eachother, 
     * then updates the FillRing object.
    */
    {
        currentHealth = currentHealth - DamageTaken;
        float fillamount = currentHealth / 100f;
        FillRing.fillAmount = fillamount;
    }
    public void HideHealthRingOverlay()
    {
        // sets Health Ring to false
        gameObject.SetActive(false);
    }

}
