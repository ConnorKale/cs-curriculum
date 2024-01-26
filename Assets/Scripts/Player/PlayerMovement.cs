using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool overworld;
    public float jumpForce;
    private float walkingSpeed;
    private float xDirection;
    private float xVector;
    private float yDirection;
    private float yVector;
    Rigidbody2D rb2D;
    private bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        walkingSpeed = 4;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        xVector = xDirection * walkingSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, 0, 0);

        if (overworld)
        {
            yDirection = Input.GetAxis("Vertical");
            yVector = yDirection * walkingSpeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(0, yVector, 0);
        }
        else
        {
            // Debug.Log(Input.GetAxis("Vertical"));
            canJump = Physics2D.Raycast(transform.position, Vector2.down, 1);
            Debug.DrawRay(transform.position, Vector2.down, Color.red);
        
        
            if (canJump && Input.GetKeyDown("space"))
            {
                Debug.Log("Jumping");
               
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
    }
}