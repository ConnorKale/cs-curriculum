using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenDoor : MonoBehaviour
{
    public GameObject innerDoor;
    private CollectAxe collectAxe;

    // Start is called before the first frame update
    void Start()
    {
        collectAxe = GameObject.FindObjectOfType<CollectAxe>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");
        
        if (other.gameObject.CompareTag("Player") && collectAxe.haveAxe == true)
        {
            innerDoor.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
