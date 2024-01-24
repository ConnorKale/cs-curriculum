using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAxe : MonoBehaviour
{
    public bool haveAxe;
    private TopDown_AnimatorController topDownAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        topDownAnimatorController = GameObject.FindObjectOfType<TopDown_AnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            haveAxe = true;
            other.gameObject.SetActive(false);
            Debug.Log("Grabbed axe");
            topDownAnimatorController.SwitchToAxe();
        }
    }
}
