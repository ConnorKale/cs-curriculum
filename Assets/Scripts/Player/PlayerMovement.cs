using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool overworld;
    private float walkingSpeed;
    private float xDirection;
    private float xVector;
    private float yDirection;
    private float yVector;
    Rigidbody2D rb2D;
    private bool jumped;
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
        // Debug.Log(Input.GetAxis("Vertical"));
        jumped = false;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!overworld && !jumped && other.gameObject.CompareTag("CaveGround") && Input.GetKey("space"))
        {
            Debug.Log("Jumping");
            jumped = true;
            rb2D.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
        }
    }
}