using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private HUD hud;
    private bool iframes;
    
    private float timer;
    private float originalTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();

        originalTimer = 1.5f;
        
        timer = originalTimer;
        iframes = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (iframes)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                    iframes = false;
                    timer = originalTimer;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            ChangeHealth(1);
        }
        if (other.gameObject.CompareTag("Turret_Projectile"))
        {
            ChangeHealth(2);
            other.gameObject.SetActive(false);
        }

    }

    void ChangeHealth(int amount)
    {
        if (!iframes)
        {
            iframes = true;
            hud.health -= amount;
        }
    }
}