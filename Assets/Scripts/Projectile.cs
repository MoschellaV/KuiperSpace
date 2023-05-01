using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Getting effects
    public GameObject bulleteffect;
    public GameObject breakeffect;
    public GameObject a1effect;
    public GameObject a2effect;
    public GameObject a3effect;

    public void OnTriggerEnter2D(Collider2D collision)
        //Detects when another object enters a trigger collider attached to this object
    {
        switch(collision.gameObject.tag) // Checks the tag of the object that this gameObject has collided with
        {
            case "Wall": 
                Instantiate(bulleteffect, transform.position, Quaternion.identity); // Instantiates the bullet effect
                Destroy(gameObject); // Destroys the bullet
                break;

            case "a1": // Asteroid 1
                Score.scoreValue += 40; // The points gained fron destroying asteroid1 is used to update the score 

                Instantiate(bulleteffect, transform.position, Quaternion.identity); // Instantiates the bullet effect
                Instantiate(breakeffect, transform.position, Quaternion.identity); // Asteroid break effect
                Destroy(collision.gameObject); // Destroys object (asteroid1) that had collided with this object (bullet)
                Destroy(gameObject); // Destroys bullet
                break;

            case "a2":
                Score.scoreValue += 29;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject); 
                break;

            case "a3":
                Score.scoreValue += 24;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject); 
                Destroy(gameObject); 
                break;

            case "a4":
                Score.scoreValue += 22;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a5":
                Score.scoreValue += 19;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a6":
                Score.scoreValue += 16;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a7":
                Score.scoreValue += 14;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a8":
                Score.scoreValue += 10;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a9":
                Score.scoreValue += 15;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a10":
                Score.scoreValue += 14;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a11":
                Score.scoreValue += 22;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "a12":
                Score.scoreValue += 31;

                Instantiate(bulleteffect, transform.position, Quaternion.identity);
                Instantiate(breakeffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "Enemy":
                Instantiate(bulleteffect, transform.position, Quaternion.identity); //bullet effect
                Destroy(collision.gameObject); //destroys enemy
                Destroy(gameObject); //destroys bullet

                break;

        }
    }
}
