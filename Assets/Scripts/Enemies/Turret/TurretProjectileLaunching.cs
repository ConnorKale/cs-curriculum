using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

///  Attach an empty child called "radius" to newly created turrets, give it radius of 2.7

public class TurretProjectileLaunching : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private float timer;
    private float originalTimer;
    public GameObject projectile;
    void Start()
    {
        originalTimer = 2;
        timer = originalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (target != null)
            {
                Instantiate(projectile, transform.position, transform.rotation);
                timer = originalTimer;
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }
}