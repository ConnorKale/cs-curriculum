using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenDoor : MonoBehaviour
{
    public GameObject innerDoor;
    private TopDown_AnimatorController topDownAnimatorController;
    private HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        topDownAnimatorController = GameObject.FindObjectOfType<TopDown_AnimatorController>();


    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update");
        if (topDownAnimatorController.IsAttacking == true)
        {
            Debug.Log("Swinging");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
//        Debug.Log("Collision");
        
        if (other.gameObject.CompareTag("Player") && hud.weapon == 1 && topDownAnimatorController.IsAttacking == true)
        {
            innerDoor.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
