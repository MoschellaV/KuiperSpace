using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //Character Select Variables
    public CharacterDatabase characterDatabase;

    public SpriteRenderer spaceShipSprite;

    public int selectedOption = 0;

    //Public variables
    public Rigidbody2D rb;
    public Camera cam;
    public float fSpeed = 5f, fMaxSpeed = 15.0f, fFriction = 0.5f;

    public float elapsedTime = 0;
    public float shockWaveCooldown = 15;

    //public float testtime = 1;
    //public float testamp = 1;

   
    private int powerType;
    private bool justUsedPower = false;

    // Delegates (for ships unique abilities)
    public delegate void AbilityDelegate();
    private AbilityDelegate abilityDelegate;

    public delegate void AbilityReadyIndicatorText();
    private AbilityReadyIndicatorText abilityReadyIndicatorText;

    public delegate void AbilityHideIndicatorText();
    private AbilityHideIndicatorText abilityHideIndicatorText;

    public delegate void CameraShakeForAbility(float amplitude, float time);
    private CameraShakeForAbility cameraShakeForAbility;

    //Calls to other files
    public Turret turret;
    public Health health;
    public HealthV2 healthv2;
    public PowerProgressbar powerProgressbar;

    //Private variables
    private Vector2 mousePosition;

    Vector2 movement, movementOrder;
    bool moveW = false, moveA = false, moveS = false, moveD = false;
    

    void Start()
    {
        /* Will load the selected player
         * 
         * If no player selected then by default player will be ship 1 and delegates will be set equal to functions that pretain to ship 1
         * 
         * If a ship is selected, delegates are set equal to functions that pretain to that ship (power up, cooldown bar, powertype)
         * 
         * Selected ship sprite is then updated
         */
        rb = GetComponent<Rigidbody2D>();
        
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
            powerType = 1;
            abilityDelegate = turret.ShockWave;
            abilityReadyIndicatorText = powerProgressbar.DisplayShockWaveReady;
            abilityHideIndicatorText = powerProgressbar.HideReady;
        }
        else
        {   
            Load();
            if (selectedOption == 0)
            {
                powerType = 1;
                abilityDelegate = turret.ShockWave;
                abilityReadyIndicatorText = powerProgressbar.DisplayShockWaveReady;
                abilityHideIndicatorText = powerProgressbar.HideReady;
                
                //Debug.Log("ship 0");
            }
            else if (selectedOption == 1)
            {
                powerType = 2;
                abilityDelegate = turret.SlowTime;
                abilityReadyIndicatorText = powerProgressbar.DisplaySlowTimeReady;
                abilityHideIndicatorText = powerProgressbar.HideReady;

                //Debug.Log("ship 1");
            }
            else if (selectedOption == 2)
            {
                powerType = 3;
                abilityDelegate = turret.Shield;
                abilityReadyIndicatorText = powerProgressbar.DisplayShieldReady;
                abilityHideIndicatorText = powerProgressbar.HideReady;
                
                //Debug.Log("ship 2");
            }
        }
        UpdateCharacter(selectedOption);
    }
    // This method updates every frame

    private void Update()
    {
        /* Delays cooldown bar by X seconds if slowTime and shield are used
         * 
         * The player can shoot using RMB and use their ability using space
         * 
         * Depending on the ability used the camera will shake by a specified amount
         * 
         */

        if (powerType == 3 && justUsedPower)
        {
            elapsedTime = -7;
            justUsedPower = false;
        }
        if (powerType == 2 && justUsedPower)
        {
            elapsedTime = -9;
            justUsedPower = false;
        }

        elapsedTime += Time.deltaTime;
        
        powerProgressbar.GetCurrentFill(elapsedTime, shockWaveCooldown);
        
             
        if (healthv2.currentHealth > 0)
        {
            RotateToMouse();
            TakeInput();

            if (Input.GetButtonDown("Fire1") & Time.timeScale != 0)
            {
                turret.Shoot();

                CameraShake.Instance.CinemachineCameraShaker(1.3f, 0.05f);
            }

            if (elapsedTime > shockWaveCooldown)
            {
                abilityReadyIndicatorText();
            }

            if (Input.GetButtonDown("Jump") && elapsedTime > shockWaveCooldown) //Gets spacebar down
            {
                elapsedTime = 0;
                
                abilityDelegate();
                abilityHideIndicatorText();
                
                
                switch (powerType)
                {
                    case 1:
                        CameraShake.Instance.CinemachineCameraShaker(5f, 1f);
                        break;
                    case 2:
                        CameraShake.Instance.CinemachineCameraShaker(1f, 0.3f);
                        break;
                    case 3:
                        CameraShake.Instance.CinemachineCameraShaker(2f, 0.5f);
                        break;
                }
                justUsedPower = true;

            }

        }
    }

    private void FixedUpdate()
    {
        // This method updates every time phyisics engine is needed
        MoveCalculations();
        Friction();

        // Actually updates the position
        gameObject.transform.position = gameObject.transform.position + (Vector3)movement * fSpeed * Time.fixedDeltaTime;
    }
    private void RotateToMouse()
    {
        // Is responsible for pointing the object at the mouse's position
     

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 direction = mousePosition - rb.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        // Math.Atan2, returns the angle whose tangent is the quotient of two values in this case it is our x and y direction
        // Mathf.Rad2Deg converts radians to degrees

        rb.rotation = angle;  
    }
    private void TakeInput()
    {
        /* Checks if key is down (pressed) or up (not pressed)
        * based on this, the boolean value for the movement variables
        * are updated
        */
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveW = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveA = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveS = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveD = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveW = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveA = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveS = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveD = false;
        }
    }
    private void MoveCalculations()
    {
        /* The conditions below determine the direction of movement
         * Note that the sign (negative/positive) denotes direction on an axis
         */

        // Movement Direction for y axis 
        if (moveW && !moveS) // Checks if moving up and not down
        {
            movementOrder.y = fMaxSpeed; // The speed must then be positive
        }
        else if (moveS && !moveW) // Checks if moving down and not up
        {
            movementOrder.y = -fMaxSpeed; // The speed must be negative
        }
        else if (moveS && moveW) // Checks if moving up and down
        {
            movementOrder.y = 0; // The forces cancel out so there is no movement
        }

        if (moveD && !moveA) 
        {
            movementOrder.x = fMaxSpeed;
        }
        else if (moveA && !moveD)
        {
            movementOrder.x = -fMaxSpeed;
        }
        else if (moveA && moveD)
        {
            movementOrder.x = 0;
        }

        //Execute 
        if (moveW && movement.y < movementOrder.y)
        // if moving up and y velocity is more than the order (order is = negative/positive speed)
        // than the y velocity is increased
        // This code is repeated
        // These conditions allow the player to gradually increase in speed
        {
            movement.y += fSpeed * Time.fixedDeltaTime;
        }
        if (moveS && movement.y > movementOrder.y)
        {
            movement.y -= fSpeed * Time.fixedDeltaTime;
        }
        if (moveA && movement.x > movementOrder.x)
        {
            movement.x -= fSpeed * Time.fixedDeltaTime;
        }
        if (moveD && movement.x < movementOrder.x)
        {
            movement.x += fSpeed * Time.fixedDeltaTime;
        }
    }
    private void Friction()
    {
        /* Calculates friction so that object can gradually slow down
         */

        if (!moveW && !moveS && movement.y > 0)
        // Basically if moving up (and not down) and there is velocity on y axis that is greater than 0 (y > 0)
        // Then apply friction to resist the movement.y variable ( 0 < friction < 1 )
        // This code is repeated
        {
            movement.y -= fSpeed * fFriction * Time.fixedDeltaTime;
        }
        else if (!moveW && !moveS && movement.y < 0)
        {
            movement.y += fSpeed * fFriction * Time.fixedDeltaTime;
        }

        if (!moveD && !moveA && movement.x > 0)
        {
            movement.x -= fSpeed * fFriction * Time.fixedDeltaTime;
        }
        else if (!moveD && !moveA && movement.x < 0)
        {
            movement.x += fSpeed * fFriction * Time.fixedDeltaTime;
        }
    }
    private void UpdateCharacter(int selectedOption)
    {
        /* Gets current character from the database 
         * displays it along with its name
         */
        Character character = characterDatabase.GetCharacter(selectedOption);
        spaceShipSprite.sprite = character.characterSprite;
        
    }
    private void Load()
    {
        // Loads selected option by converting the assigned key value to an integer
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

}   
    