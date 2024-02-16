using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP1 : MonoBehaviour
{
    private HUD hud;
    private Platformer_Animator pa;
    
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        pa = GameObject.FindObjectOfType<Platformer_Animator>();
        
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
        Debug.Log(pa.IsAttacking);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Hitting something");
        if (other.gameObject.CompareTag("Player") && pa.IsAttacking)
        {
            hud.cp1 = true;
            gameObject.SetActive(false);
        }
    }
}
