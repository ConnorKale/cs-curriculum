using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAxe : MonoBehaviour
{
    private HUD hud;
    private TopDown_AnimatorController topDownAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        topDownAnimatorController = GameObject.FindObjectOfType<TopDown_AnimatorController>();

        if (hud.weapon == 1)
        {
            topDownAnimatorController.SwitchToAxe();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Axe"))
        {
            if (hud.weapon < 1)
            {
                hud.weapon = 1;
            }
            other.gameObject.SetActive(false);
            Debug.Log("Grabbed axe");
            topDownAnimatorController.SwitchToAxe();
        }
    }
}
