using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeInnerColliderDetection : MonoBehaviour
{
    private AxeMobileEnemyBehavior amem;
    
    // Start is called before the first frame update
    void Start()
    {
        amem = GetComponentInParent<AxeMobileEnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            amem.target = other.gameObject;
        }
    }
}