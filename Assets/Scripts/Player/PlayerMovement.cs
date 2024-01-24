using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool overworld;
    private float walkingSpeed;
    private float jumpForce;
    private float xDirection;
    private float xVector;
    private float yDirection;
    private float yVector;
    
    // Start is called before the first frame update
    void Start()
    {
        walkingSpeed = 4;
        jumpForce = 2000;
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
        if (overworld == false)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Debug.Log("Jumping");
                yVector -= jumpForce;
            }
        }
        // Debug.Log(Input.GetAxis("Vertical"));
    }
}
