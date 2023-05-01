using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRednessScript : MonoBehaviour
{
    public Color red;
    public Color transparent;

    Color currentColor;

    MeshRenderer myRenderer;

    private void Start()
    {
        
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = red;
        currentColor = red;
    }

    private void Update()
    {
        
    }
    public IEnumerator MakeScreenRed()
    {
        gameObject.SetActive(true); // Activates the game over screen so it is visible to the player
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);


    }

    public void ColourChanging()
    {
        myRenderer.material.color = Color.Lerp(myRenderer.material.color, currentColor, 0.1f);
    }
    

}
