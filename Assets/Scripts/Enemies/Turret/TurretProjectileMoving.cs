using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretProjectileMoving : MonoBehaviour
{
    public Vector3 target;
    private float timer;
    private GameObject player;
    private float distance;
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
        distance = 6.28f * Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, distance);
        }

        if (transform.position == target)
        {
            Destroy(gameObject);
        }
        

    }
}