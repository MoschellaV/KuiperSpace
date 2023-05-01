using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //Calls to other fils
    public Health health;
    public HealthV2 health2;

    //Getting effects
    public GameObject a1effect;
    public GameObject a2effect;
    public GameObject a3effect;

    private void OnCollisionEnter2D(Collision2D other)
    
    /* Runs every time a collision happens 
    *  between the player and any other object 
    */
    {
        if (other.gameObject.tag != "Wall")
        // Checks if the other object is tagged as something that is not a wall
        {         
            Destroy(other.gameObject); // Destroys other object

            CameraShake.Instance.CinemachineCameraShaker(7f, 0.7f); // Shakes screen

            switch (other.gameObject.tag)
            {
                case "a1":
                    health2.GetHealthFill(24); // Health deducted from being hit by a1
                    Instantiate(a1effect, transform.position, Quaternion.identity); //asteroid 1 breaking effect
                    break;

                case "a2":
                    health2.GetHealthFill(22);
                    Instantiate(a2effect, transform.position, Quaternion.identity);
                    break;

                case "a3":
                    health2.GetHealthFill(20);
                    Instantiate(a3effect, transform.position, Quaternion.identity);
                    break;

               case "a4":
                    health2.GetHealthFill(18);
                    break;

                case "a5":
                    health2.GetHealthFill(17);
                    break;

                case "a6":
                    health2.GetHealthFill(16);
                    break;

                case "a7":
                    health2.GetHealthFill(15);
                    break;

                case "a8":
                    health2.GetHealthFill(15);
                    break;

                case "a9":
                    health2.GetHealthFill(14);
                    break;

                case "a10":
                    health2.GetHealthFill(13);
                    break;

                case "a11":
                    health2.GetHealthFill(11);
                    break;

                case "a12":
                    health2.GetHealthFill(9);
                    break;
            }
        }
    }
}