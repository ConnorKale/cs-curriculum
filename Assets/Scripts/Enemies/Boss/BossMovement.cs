using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Boss behavior: rotate around player, shoot projectiles at them
    
    private float rotation;
    private Vector3 axis;
    private float rotationSpeed;
    private float preferredDistanceFromPlayer;
    private float correction;
    public Vector3 target;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        preferredDistanceFromPlayer = 4;
        rotation = 0;
        axis = new Vector3(0, 0, 1);
        rotationSpeed = 72; //Degrees per second

    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
        
        correction = Vector3.Distance (target, gameObject.transform.position);
        correction -= preferredDistanceFromPlayer;
        transform.position = Vector3.MoveTowards(transform.position, target, correction);


        rotation = (rotationSpeed*Time.deltaTime);
        this.gameObject.transform.RotateAround(target, axis, rotation);
        transform.rotation = Quaternion.Euler(Vector3.forward);

    }
}
