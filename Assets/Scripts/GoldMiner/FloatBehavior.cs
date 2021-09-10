using System;
using System.Collections;
using UnityEngine;

public class FloatBehavior : MonoBehaviour
{
    float originalY;
    public float floatStrength = 0.3f;
    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Math.Sin(Time.time) * floatStrength),
            transform.position.z);
    }
}
