using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMovement : MonoBehaviour
{
    private float walkingSpeed;
    private float xDirection;
    private float xVector;
    
    // Start is called before the first frame update
    void Start()
    {
        walkingSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        xVector = xDirection * walkingSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector, 0, 0);
    }
}