using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    [SerializeField] private float speed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
    }
}
