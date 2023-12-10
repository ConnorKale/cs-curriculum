using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    private int size; //Circle sprite's radius

    // Start is called before the first frame update
    void Start()
    {
        size = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //for each other loaded object:
        //object moves towards me a number of pixels equal to 100/distance^2
    }
}
