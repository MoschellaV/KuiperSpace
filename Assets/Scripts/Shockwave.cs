using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    public Animator anim;

    public float timer = 0;
    public float gorwTime = 2;
    public float maxSize = 2;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>(); 
    }
    private void Update()
    {
        // The Coroutine is started immediately becuase as soon as the object is instantiated
        // this script will run.
        try
        {
            anim.Play("ShockWaveAnimation");
        }
        catch { }
        StartCoroutine(WaveGrowth());
    }
    public IEnumerator WaveGrowth()
        /* IEnumerator is used here b/c we are using a timer. The objects local scale is held in a variable
         * "startscale" the max size is then assigned a "maxScale".  A while loop is used to continuously 
         * increase the size of the object while also incrementing the "timer" variable.  Once the 
         * timer is greater than the grow time the gameObject is destroyed. 
         */
    {
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        //this statment executes until the while loop's condition is no longer true
        do
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / gorwTime);
            // Lerp takes a start value "startscale" an end value "maxScale" and a value used to interpolate
            // So it gradually goes from point A to B.  This is how the size is increased.

            timer += Time.deltaTime;

            yield return null;
        }
        while (timer < gorwTime);

        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) // Checks the tag of the object that this gameObject has collided with
        {
            case "Wall": 

                //Do nothing

                break;

            case "a1":
                Score.scoreValue += 40; // The points gained fron destroying asteroid1 is used to update the score 

                Destroy(collision.gameObject); // Destroys object that had collided with this object

                break;

            case "a2":
                Score.scoreValue += 29;

                Destroy(collision.gameObject);
                
                break;

            case "a3":
                Score.scoreValue += 24;

                Destroy(collision.gameObject);
                
                break;

            case "a4":
                Score.scoreValue += 22;

                Destroy(collision.gameObject);
             
                break;

            case "a5":
                Score.scoreValue += 19;


                Destroy(collision.gameObject);
                
                break;

            case "a6":
                Score.scoreValue += 16;

                Destroy(collision.gameObject);
                
                break;

            case "a7":
                Score.scoreValue += 14;

                Destroy(collision.gameObject);
               
                break;

            case "a8":
                Score.scoreValue += 10;

                Destroy(collision.gameObject);
            
                break;

            case "a9":
                Score.scoreValue += 15;              

                Destroy(collision.gameObject);
          
                break;

            case "a10":
                Score.scoreValue += 14;

                Destroy(collision.gameObject);
           
                break;

            case "a11":
                Score.scoreValue += 22;

                Destroy(collision.gameObject);
         
                break;

            case "a12":
                Score.scoreValue += 31;

                Destroy(collision.gameObject);
               
                break;
        }
    }
}
