using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public static SlowTime Instance { get; private set; }

    private Transform player;
    private Component a1;

    public EnemyController enemyController;

    private float timer;
    public bool isSlowing = false;

    void Start()
    {
        Instance = this;
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        /* As soon as this object is instantied it activates the 
         * blue vignette and starts a timer that destroys this object in 9s
         */
        isSlowing = true;

        timer += Time.deltaTime;
        SlowAsteroids();

        if (timer >= 9)
        {
            isSlowing = false;
            Destroy(gameObject);
        }

    }

    public void SlowAsteroids()
    {
        // Activates a blue vignette set to the player's position
        gameObject.transform.position = player.position;
    }

}
