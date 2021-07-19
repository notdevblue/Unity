using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMao : MonoBehaviour
{
    public float speed = 1.0f;
    public float amount = 1.0f;
    public Transform target = null;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x + Mathf.Sin(Time.time * speed) * amount, target.position.y, target.position.z + Mathf.Cos(Time.time * speed) * amount);
    }
}
