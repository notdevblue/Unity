using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sincos : MonoBehaviour
{
    public float speed = 1.0f;
    public float amount = 1.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(Time.time * speed) * amount, Mathf.Sin(Time.time * speed) * amount, 0);
    }
}
