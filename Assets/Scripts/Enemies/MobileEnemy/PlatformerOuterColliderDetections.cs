using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerOuterColliderDetections : MonoBehaviour
{
    private PlatformerMobileEnemyBehavior pmem;
    
    // Start is called before the first frame update
    void Start()
    {
        pmem = GetComponentInParent<PlatformerMobileEnemyBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pmem.target = null;
        }
    }

}
