using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// ??? Problems: Convert GameObject to Vector3 Position for MoveTowards
/// !!! Problems: Use different Coliders.


public class AxeMobileEnemyBehavior : MonoBehaviour
{
    public GameObject target;
    
    private int health;
    private int maxHealth;
    private bool iframes;
    private float timer;
    private float originalTimer;
    
    public GameObject axe; //This is always dropped.

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        maxHealth = 5;
        health = maxHealth;
        iframes = false;
        originalTimer = 1;
        timer = originalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        /// Move:
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.00625f);
        }

        /// Count down the timer.
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

        if (other.gameObject.CompareTag("Player_Projectile"))
        {
            ChangeHealth(-1);
            other.gameObject.SetActive(false);
            target = GameObject.FindWithTag("Player");
        }
    }

    private void OnTriggerEnter2D(BoxCollider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Coin_Worth1"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Coin_Worth10"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Coin_Worth1000"))
        {
            other.gameObject.SetActive(false);
        }



    }

    void ChangeHealth(int amount)
    {
        if (amount > 0)
        {
            health += amount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        
        if (amount < 0)
        {
            if (!iframes)
            {
                iframes = true;
                health += amount;
                Debug.Log("Hit");
                if (health <= 0)
                {
                    Die();
                }
            }
        }

    }

    void Die()
    {
        Debug.Log("Dead");
        Instantiate(axe, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}