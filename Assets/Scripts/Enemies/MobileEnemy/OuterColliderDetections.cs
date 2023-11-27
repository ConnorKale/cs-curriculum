using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterColliderDetections : MonoBehaviour
{
    private MobileEnemyBehavior mem;
    
    // Start is called before the first frame update
    void Start()
    {
        mem = GameObject.FindObjectOfType<MobileEnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mem.target = null;
        }
    }

}
