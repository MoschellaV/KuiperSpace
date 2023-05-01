using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV1 : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float Speed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Gets rigidobdy of gameobject
    }

    void Update()
    /* Gets any input on the horizontal and vertical axis
     *  
     */
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    /* Sets the rigidbody's velocity to the value calculated (value is a 2d vector)
     * 
     */
    {
        body.velocity = new Vector2(horizontal * Speed, vertical * Speed);
    }

}