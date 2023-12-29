using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotation;
    private Vector3 axis;
    private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rotation = 0;
        axis = new Vector3(0, 0, 1);
        rotationSpeed = 144; //Degrees per second
    }

    // Update is called once per frame
    void Update()
    {
        rotation = (rotationSpeed*Time.deltaTime);
        Debug.Log(string.Format("deltatime {0} rotation {1}", Time.deltaTime, rotation));
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, axis, rotation);
    }
}
