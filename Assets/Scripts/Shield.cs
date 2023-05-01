using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Transform player;
    

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        HasTheShield();

        if (timer >= 7f)
        {
            DestroyTheShield();
        }

    }

    public void HasTheShield()
    {
        // Sets the circle to the players position and rotate it (rotation is so it looks cool)
        gameObject.transform.position = player.position;
        transform.Rotate(Vector3.forward * -6);
    }

    public void DestroyTheShield()
    {
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
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); // Camera Shake
                break;

            case "a2":
                Score.scoreValue += 29;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a3":
                Score.scoreValue += 24;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a4":
                Score.scoreValue += 22;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a5":
                Score.scoreValue += 19;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a6":
                Score.scoreValue += 16;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a7":
                Score.scoreValue += 14;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a8":
                Score.scoreValue += 10;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a9":
                Score.scoreValue += 15;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a10":
                Score.scoreValue += 14;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a11":
                Score.scoreValue += 22;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;

            case "a12":
                Score.scoreValue += 31;

                Destroy(collision.gameObject);
                CameraShake.Instance.CinemachineCameraShaker(3f, 0.5f); 
                break;
        }
    }
}
