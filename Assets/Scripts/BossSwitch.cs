using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwitch : MonoBehaviour
{
    private Platformer_Animator pa;
    
    public GameObject boss;
    public GameObject wall;

    private bool hit;
    
    public Vector2 Wall1Position;
    public Vector2 Wall2Position;
    public Vector2 BossStartPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        pa = GameObject.FindObjectOfType<Platformer_Animator>();

        hit = false;

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionStay2D(Collision2D other)
    {
//        Debug.Log("Hitting something");
        if (other.gameObject.CompareTag("Player") && pa.IsAttacking)
        {
            if (!hit)
            {
                Instantiate(wall, Wall1Position, transform.rotation);
                Instantiate(wall, Wall2Position, transform.rotation);
                Instantiate(boss, BossStartPosition, transform.rotation);
                transform.localScale = new Vector3(-3, 3, 1);
                hit = true;
            }
        }
    }
}