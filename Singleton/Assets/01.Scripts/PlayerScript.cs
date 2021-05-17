using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public float speed = 3f;
    private Rigidbody2D rigid;

    private float fireDelay = 1.0f;
    private float firePressed = 0.0f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float y = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector2(0, y* speed);

        if(Input.GetButtonDown("Jump")){
            Fire();
            Upgrade();
        }
    }

    void Fire()
    {
        //if(fireDelay + firePressed < Time.time)
        {
            firePressed = Time.time;
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }   
    }

    void Upgrade()
    {
        if(GameManager.instance.score >= 20)
        {
            fireDelay = 0.5f;
        }
    }
}
