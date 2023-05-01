using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Transforms
    public Transform player;
    public Transform firePoint;

    // Shield
    public GameObject playerShield;

    // Shockwave 
    public GameObject wave;

    // SlowTime
    public GameObject playerSlowTime;

    // Main player script
    public PlayerController playerController;

    // Bullet gameobjects and firepoint position
    public GameObject blueBullet;
    public GameObject yellowBullet;
    public GameObject orangeBullet;
    
    // variables
    public float fireForce;
    private GameObject bullet;
    
    private void Start()
    {
        // Gets which ship is being used and sets bullet to corresponding sprite
        if (playerController.selectedOption == 0)
        {
            bullet = orangeBullet;
        }
        else if (playerController.selectedOption == 1)
        {
            bullet = yellowBullet;
        }
        else if (playerController.selectedOption == 2)
        {
            bullet = blueBullet;
        }
    }
    public void Shoot()
    {
        
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        // Spawns a bullet at the firepoint's position and rotation
        // Firepoint being a child object of the player attached to the end of the turret
        // This method is public becuase it will be called from another file

        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        // Gets rigidbody
        // Adds an IMPULSE force in the up direction of firepoint multiplied by a specifiec force value

    }
    public void ShockWave()
    {
        // Instantiates a shockwave at the current player's position (the position at the time this function was called) 
        var currplayerpos = player.position;
        var shockwave = Instantiate(wave, currplayerpos, player.rotation);
    }

    public void Shield()
    {
        // Instantiates a shield and the players position and rotation
        var shield = Instantiate(playerShield, player.position, player.rotation);
    }
    public void SlowTime()
    {
       // Instanties the slowTime effect at the players position with no rotation
        var shield = Instantiate(playerSlowTime, player.position, Quaternion.identity);
    }

}
