using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;

    public GameObject asteroid;

    public float movementSpeed;
    Vector3 pathToTarget;

    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    void MoveEnemy()
    {
        /* If the target exists asteroids will find a path to the target, otherwise they stop moving
         * 
         * The slow time power up is also done in this function.
         * If the slowTime power up is activated, the boolean value of isSlowing is gotten from 
         * another file (if it exists, its attached to a prefab).
         * This value updates the isSlowed bool, doing it this way prevents an error.
         * 
         * If the player did use the slowTime the asteroids x any y speeds are slowed
         * 
         */
        if (target != null)
        {
            pathToTarget = (target.transform.position - transform.position).normalized;

            bool isSlowed = false;
            try
            {
                if (SlowTime.Instance.isSlowing)
                {
                    isSlowed = true;
                }
            }
            catch{}

            if(isSlowed)
            {
                rb.velocity = new Vector2(pathToTarget.x * 0.50f, pathToTarget.y * 0.50f);
            }
            else
            {
                rb.velocity = new Vector2(pathToTarget.x * movementSpeed, pathToTarget.y * movementSpeed);
            }
    
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    
}

