using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileUpMoving : MonoBehaviour
{
    private float speed;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        speed = 16;
        timer = 0.3f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }

    }
}
