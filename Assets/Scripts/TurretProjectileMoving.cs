using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretProjectileMoving : MonoBehaviour
{
    public Vector3 target;
    private float timer;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        timer = 10;
        target = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);
        }

        if (transform.position == target)
        {
            gameObject.SetActive(false);
        }
    }
}
