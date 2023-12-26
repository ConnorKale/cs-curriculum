using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float rotation;
    private Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        rotation = 0;
        axis = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        rotation += 1f * Time.deltaTime;
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, axis, rotation);
    }
}
