using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMobileEnemyBehavior : MonoBehaviour
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

    private float velocity;
    private float xDifference;

    // Start is called before the first frame update
    void Start()
    {
        target = null;
        maxHealth = 3;
        health = maxHealth;
        iframes = false;
        originalTimer = 1;
        timer = originalTimer;
        velocity = 2.718281828459045f;
    }

    // Update is called once per frame
    void Update()
    {
        /// Move:
        if (target != null)
        {
            if (target.transform.position.x < transform.position.x) // Player is left of me, my x cordinate gets smaller
            {
                Debug.Log("I see player, they are left of me.");
                transform.position = transform.position - new Vector3(velocity*Time.deltaTime, 0, 0);
                if (target.transform.position.x > transform.position.x) // x cordinate got too small
                {
                    xDifference = target.transform.position.x - transform.position.x;
//                    transform.position.x = target.transform.positon.x;
                    transform.position = transform.position + new Vector3(xDifference, 0, 0);
                }
            }

            if (target.transform.position.x > transform.position.x) // Player is right of me, my x cordinate gets bigger
            {
                Debug.Log("I see player, they are right of me.");
                transform.position = transform.position + new Vector3(velocity*Time.deltaTime, 0, 0);
                if (target.transform.position.x < transform.position.x) // x cordinate got too big
                {
                    xDifference = transform.position.x - target.transform.position.x;
//                    transform.position.x = target.transform.positon.x;
                    transform.position = transform.position - new Vector3(xDifference, 0, 0);
                }

            }

            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocity*Time.deltaTime);
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
            ChangeHealthIframes(-2);
        }

        if (other.gameObject.CompareTag("Player_Projectile"))
        {
            ChangeHealth(-1);
            Destroy(other.gameObject);
            target = GameObject.FindWithTag("Player");
        }
    }

    private void OnTriggerEnter2D(BoxCollider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other);
        }

        if (other.gameObject.CompareTag("Coin_Worth1"))
        {
            Destroy(other);
        }

        if (other.gameObject.CompareTag("Coin_Worth10"))
        {
            Destroy(other);
        }

        if (other.gameObject.CompareTag("Coin_Worth1000"))
        {
            Destroy(other);
        }



    }

    void ChangeHealthIframes(int amount)
    {
        if (!iframes)
        { 
            iframes = true;
            health += amount;
//          Debug.Log("Hit");
            if (health <= 0)
            { 
                Die();
            }
        }

    }

    void ChangeHealth(int amount)
    {
        health += amount;
        Debug.Log("Hit");
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        { 
            Die();
        }
    }
    
    
    void Die()
    {
//      Debug.Log("Dead");
        int d20 = Random.Range(1, 21);
        if (d20 == 1)
        {
//            Debug.Log("I think you rolled a nat one. You rolled " + d20 + ".");
        }
        if (d20 > 1 && d20 < 11)
        {
//            Debug.Log($"I think you rolled 2-10. You rolled {d20}.");
            Instantiate(copperCoin, transform.position, transform.rotation);
        }
        if (d20 > 10 && d20 < 20)
        {
//            Debug.Log("I think you rolled 11-19. You rolled " + d20 + ".");
            Instantiate(heart, transform.position, transform.rotation);
        }
        if (d20 == 20)
        {
//            Debug.Log("I think you rolled 20. You rolled " + d20 + ".");
            Instantiate(silverCoin, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}