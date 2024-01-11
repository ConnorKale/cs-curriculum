using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Input.GetAxis("Horizontal") is negitive one if left arrow is pressed and positive one if right arrow is pressed.
// Input.GetAxis("Vertical") is negitive one if down arrow is pressed and positive one if up arrow is pressed.
// Both are floats, cannot be converted to ints.


/// Prioritize looking left or right.
public class PlayerProjectileLaunching : MonoBehaviour
{
    private HUD hud;
    
    // Private variables that tell us what direction we're looking:
    private float xDirection;
    private float yDirection;
    private bool xArrowDown;
    private bool yArrowDown;

    // Public variables that shoot the arrow.
    public GameObject upProjectile;
    public GameObject downProjectile;
    public GameObject leftProjectile;
    public GameObject rightProjectile;




    // Start is called before the first frame update
    void Start()
    {
        xDirection = 0;
        yDirection = -1;
        xArrowDown = false;
        yArrowDown = false;
        hud = GameObject.FindObjectOfType<HUD>();

    }

    // Update is called once per frame
    void Update()
    {
        /// Check if left arrow was pressed. Set xArrowDown to true and xDirection to be -1.
        if (!xArrowDown && Input.GetAxis("Horizontal") < 0)
        {
            xArrowDown = true;
            xDirection = -1;
        }

        /// Check if right arrow was pressed. Set xArrowDown to true and xDirection to be 1.
        if (!xArrowDown && Input.GetAxis("Horizontal") > 0)
        {
            xArrowDown = true;
            xDirection = 1;
        }

        /// Check if left and right arrows are not pressed. Set xArrowDown to false.
        if (xArrowDown && Input.GetAxis("Horizontal") == 0)
        {
            xArrowDown = false;
        }


        /// Check if up arrow was pressed. Set yArrowDown to true and yDirection to be 1.
        if (!yArrowDown && Input.GetAxis("Vertical") > 0)
        {
            yArrowDown = true;
            yDirection = 1;
        }
        /// Check if left arrow was pressed. Set yArrowDown to true and yDirection to be -1.
        if (!xArrowDown && Input.GetAxis("Vertical") < 0)
        {
            yArrowDown = true;
            yDirection = -1;
        }

        /// Check if up and down arrows are not pressed. Set yArrowDown to false.
        if (yArrowDown && Input.GetAxis("Vertical") == 0)
        {
            yArrowDown = false;
        }

        // Check if player is moving left or right, NOT moving up or down. If so, set yDirection to 0.
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0)
        {
            yDirection = 0;
        }
        
        // Check if player is moving up or down, NOT moving left or right. If so, set xDirection to 0.
        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") == 0)
        {
            xDirection = 0;
        }

        // Shooting projectiles:
        if (xDirection == 1) // We are looking right
        {            
            if (Input.GetKeyDown(KeyCode.Space)) // Space is pressed
            {
                if (hud.coins > 0)
                {
                    Instantiate(rightProjectile, transform.position, transform.rotation);
                    hud.coins -= 1;
                }
            }


        }
        
        if (xDirection == -1)
        {            
            if (Input.GetKeyDown(KeyCode.Space)) // Space is pressed
            {
                if (hud.coins > 0)
                {
                    Instantiate(leftProjectile, transform.position, transform.rotation);
                hud.coins -= 1;
                }

            }

        }


        if (yDirection == 1 && xDirection == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Space is pressed
            {
                if (hud.coins > 0)
                {
                    Instantiate(upProjectile, transform.position, transform.rotation);
                hud.coins -= 1;
                }

            }

        }

        if (yDirection == -1 && xDirection == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Space is pressed
            {
                if (hud.coins > 0)
                {
                    Instantiate(downProjectile, transform.position, transform.rotation);
                hud.coins -= 1;
                }

            }

        }
    }
}
