using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{

    public GameObject[] enemies; //array of enemies 
    public Transform[] spawnPoints; // array of spawn points

    int randSpawnPoint;
    int randEnemy;

    int difficultyMultiplier;
    int prevDifficultyMultiplier;
    float spawnTime = 2.5f;

    void Start()
    {
        // This method invokes the SpawnEnemy function, it starts invoking in 0 seconds, and repeats ever X seconds
        // This is put in Start b/c we need this process to begin
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);

    }
    private void Update()
    {
        // Calculates the difficulty multiplier by divinding the score by 200
        // This makes it so the game gets harder every 200 score points
        difficultyMultiplier = Score.scoreValue / 200;
        
        if (Mathf.Floor(difficultyMultiplier) == 0) 
            // This statment catches a 0 division error 
        {
            //Do nothing
        }
        
        else if (difficultyMultiplier > prevDifficultyMultiplier) 
            //Checks if the difficulty has increased
            //If the difficulty has increased this if statment will make the game harder 
        {
            CancelInvoke(); // Stops all Invoke Operations (the previous InvokeRepeating method)

            if (spawnTime > 1.7)
                // Makes it so that the game gets harder quicker at the beginning
            {
                spawnTime -=  0.12f; // Reduces spawn time by 0.12s
            }
            else if (spawnTime > 0.75)
                // This if statment caps the spawn time at about 0.7s
            {
                spawnTime -= 0.08f; // Reduces spawn time by 0.08s
            }
            
            InvokeRepeating("SpawnEnemy", 0f, spawnTime); //Invoke is then called again, this time with the new spawnTime
        }

        prevDifficultyMultiplier = difficultyMultiplier; // Stores the last difficultyMultiplier
    }

    void SpawnEnemy()
    {
        // gets a random spawn point by randomly indexing the array of spawnpoints
        randSpawnPoint = Random.Range(0, spawnPoints.Length);

        // gets a random enemy prefab  by randomly indexing the array of enemies
        randEnemy = Random.Range(0, enemies.Length);

        //Instantiate/Spawn the random enemy at the random spawn point
        Instantiate(enemies[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);
        // 1st argument we index the enemies list to select the random enemy that will be spawned
        // 2nd argument we index the spawn point list to select the random spawnpoint  that we want to spawn at
            // we add .position to this argument becuase we want the spawn point's position
        //Quaternion.identity is a complicated way of saying no rotation

    }
}
