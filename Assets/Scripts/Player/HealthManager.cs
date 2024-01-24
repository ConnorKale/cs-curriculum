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
            ChangeHealth(-2);
        }
        
        if (other.gameObject.CompareTag("Turret_Projectile"))
        {
            ChangeHealth(-1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(-3);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heart_Worth3"))
        {
            ChangeHealth(3);
            Debug.Log("Heart_Worth3 Collected");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Turret_Projectile"))
        {
            ChangeHealth(-1);
            Destroy(other.gameObject);
            Debug.Log("Projectile Hit");
        }

    }

    void ChangeHealth(int amount) /// Adds amount to the player's health.
    {
        if (amount > 0)
        {
            hud.health += amount;
            if (hud.health > hud.maxHealth)
            {
                hud.health = hud.maxHealth;
            }
        }
        
        if (amount < 0)
        {
            if (!iframes)
            {
                iframes = true;
                hud.health += amount;
            }
        }

    }
}