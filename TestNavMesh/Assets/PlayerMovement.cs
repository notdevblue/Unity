using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDir     = Vector3.zero;
    private Vector3 rotateDir   = Vector3.zero;
    private CharacterController charCon;

    public float moveSpeed      = 1.5f;
    public float rotateSpeed    = 1.5f;
    public float jumpSpeed      = 1.5f;
    public float gravity        = 9.8f;


    void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
    }

    void Update()
    {
        rotateDir = Vector3.zero;

        // 이동
        moveDir.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveDir.z = Input.GetAxis("Vertical")   * moveSpeed;

        // 회전
        if(Input.GetKey(KeyCode.Q))
        {
            rotateDir.y -= rotateSpeed;
        }
        if(Input.GetKey(KeyCode.E))
        {
            rotateDir.y += rotateSpeed;
        }


        // 점프
        if(charCon.isGrounded && Input.GetButton("Jump"))
        {
            moveDir.y = jumpSpeed;

        }

        moveDir.y -= gravity * Time.deltaTime;
        transform.Rotate(rotateDir * Time.deltaTime);
        charCon.Move(moveDir * Time.deltaTime);

        
    }
}
