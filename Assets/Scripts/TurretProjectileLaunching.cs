using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

///  Need timer, child > detection collider, turret

public class TurretProjectileLaunching : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 target;
    private float timer;
    private float originalTimer;
    private bool timerCounting;
    public GameObject projectile;
    void Start()
    {
        originalTimer = 2;
        timer = originalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && timerCounting == false)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timerCounting = true;
        }
        
        
        if (timer > 0 && timerCounting)
        {
            timer -= Time.deltaTime;
        }
        
        if (timer < 0)
        {
            timer = originalTimer;
            timerCounting = false;
        }
    }
    
    void OnTriggerEnter2D(CircleCollider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other;
        }
    }
}