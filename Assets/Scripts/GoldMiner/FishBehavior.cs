using System;
using System.Collections;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    float originalX;
    public float floatStrength;
    void Start()
    {
        this.originalX = this.transform.position.x;
    }

    void Update()
    {
        Debug.Log((float)Math.Sin(Time.time) * floatStrength);
        if ((float)Math.Sin(Time.time) * floatStrength > floatStrength - 0.1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if ((float)Math.Sin(Time.time) * floatStrength < -floatStrength + 0.1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        transform.position = new Vector3(originalX + ((float)Math.Sin(Time.time) * floatStrength), transform.position.y,
            transform.position.z);
    }
}
