using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public bool vertical;
    public float originalTimer;
    public float originalVelocity;

    private float timer;
    private float velocity;
    // Start is called before the first frame update
    void Start()
    {
        timer = originalTimer;
        velocity = originalVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = originalTimer;
            velocity *= -1;
        }
        
        // If the platform moves up and down, vertical is true.
        if (vertical)
        {
            transform.position = transform.position + new Vector3(0, (velocity * Time.deltaTime), 0);
        }
        
        // If the platform moves left and right, vertical is false.
        if (!vertical)
        {
            transform.position = transform.position + new Vector3((velocity * Time.deltaTime), 0, 0);
        }
    }
}
