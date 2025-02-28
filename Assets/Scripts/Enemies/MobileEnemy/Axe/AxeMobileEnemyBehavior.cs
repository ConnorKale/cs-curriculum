using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    
    private HUD hud;
    public GameObject axe; //This is dropped if you have no axe.
    public GameObject silverCoin;

    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        target = null;
        maxHealth = 5;
        health = maxHealth;
        iframes = false;
        originalTimer = 1;
        timer = originalTimer;
        velocity = 3.141592653589790f;
    }

    // Update is called once per frame
    void Update()
    {
        /// Move:
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocity * Time.deltaTime);
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
 //         Debug.Log("Hit");
            if (health <= 0)
            { 
                Die();
            }
        }
    }

    void ChangeHealth(int amount)
    {
        health += amount;
//      Debug.Log("Hit");
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
        if (hud.weapon == 0)
        {
            Instantiate(axe, transform.position, transform.rotation);

        }
        else
        {
            Instantiate(silverCoin, transform.position, transform.rotation);

        }
        gameObject.SetActive(false);
    }
}