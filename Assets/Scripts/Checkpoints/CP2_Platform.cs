using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP2_Platform : MonoBehaviour
{
    public bool vertical;
    public float originalTimer;
    public float originalVelocity;

    private float timer;
    private float velocity;

    private HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        timer = originalTimer;
        velocity = originalVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (hud.cp2)
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
}
