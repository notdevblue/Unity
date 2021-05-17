using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("BALL")){
            Destroy(other.gameObject);
        }
    }
}
