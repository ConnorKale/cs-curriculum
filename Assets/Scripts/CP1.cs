using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP1 : MonoBehaviour
{
    private HUD hud;
    private Platformer_Animator pac;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        pac = GameObject.FindObjectOfType<Platformer_Animator>();
        
        if (hud.cp1)
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hud.cp1)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && pac.IsAttacking)
        {
            hud.cp1 = true;
            gameObject.SetActive(false);
        }
    }
}
