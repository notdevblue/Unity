using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    Vector3 startPos;
    Vector3 targetPos;

    public GameObject smallerTarget = null;
    public bool isLast = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
        targetPos.y *= -1;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2f);

        transform.position = pos;

        if( (pos - targetPos).magnitude <= 0.3f ){
            targetPos.y *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BALL"))
        {
            GameManager.instance.AddScore(10);
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }

        if (isLast) Destroy(gameObject);
        //if (isLast) Destroy(gameObject);
        Instantiate(smallerTarget, new Vector2(startPos.x + Random.Range(-1.0f, 1.0f), (startPos.y + Random.Range(-2.0f, 2.0f))), transform.rotation);
        Instantiate(smallerTarget, new Vector2(startPos.x + Random.Range(-1.0f, 1.0f), (startPos.y + Random.Range(-2.0f, 2.0f))), transform.rotation);
        Destroy(gameObject);
    }
}
