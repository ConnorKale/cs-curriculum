using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// ??? Problems: Convert GameObject to Vector3 Position for MoveTowards
/// !!! Problems: Use different Coliders.


public class MobileEnemyBehavior : MonoBehaviour
{
    public GameObject target;
    
    private int health;
    private int maxHealth;
    private bool iframes;
    private float timer;
    private float originalTimer;
    
    /// Nat one offers no reward for defeating the mobile enemy.
    public GameObject copperCoin; //This is for a rolled 2-10.
    public GameObject heart; // This is for a rolled 11-19.
    public GameObject silverCoin; // This is for a natural 20.

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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);
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

        if (other.gameObject.CompareTag("Coin"))
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
        int d20 = Random.Range(1, 21);
        if (d20 == 1)
        {
            Debug.Log("I think you rolled a nat one. You rolled " + d20 + ".");
        }
        if (d20 > 1 && d20 < 11)
        {
            Debug.Log($"I think you rolled 2-10. You rolled {d20}.");
            Instantiate(copperCoin, transform.position, transform.rotation);
        }
        if (d20 > 10 && d20 < 20)
        {
            Debug.Log("I think you rolled 11-19. You rolled " + d20 + ".");
            Instantiate(heart, transform.position, transform.rotation);
        }
        if (d20 == 20)
        {
            Debug.Log("I think you rolled 20. You rolled " + d20 + ".");
            Instantiate(silverCoin, transform.position, transform.rotation);
        }
        gameObject.SetActive(false);
    }

}

// Coin is copper coin, axe is heart, bad copper coin is silver coin.