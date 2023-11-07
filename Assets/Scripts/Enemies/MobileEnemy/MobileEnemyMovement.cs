using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// ??? Problems: Convert GameObject to Vector3 Position for MoveTowards
/// !!! Problems: Use different Coliders.


public class MobileEnemyMovement : MonoBehaviour
{
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.005f);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if (Collider2D.CompareTag("MobileEnemyInnerVision"))
        // {
            if (other.CompareTag("Player"))
            {
                target = other.gameObject;
            }
        // }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
        }
    }

}
