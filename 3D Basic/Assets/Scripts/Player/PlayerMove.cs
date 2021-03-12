using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float     speed = 10.0f;
                     private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        // GetAxis    -1  ~  1
        // GetAxisRaw -1, 0, 1


        rigid.velocity = transform.forward.normalized * z * speed;
        rigid.rotation = rigid.rotation * Quaternion.Euler(0, x, 0);
        

    }
}
