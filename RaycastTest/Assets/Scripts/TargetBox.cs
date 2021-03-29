using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBox : MonoBehaviour
{
    public float        hp = 40.0f;
    public GameObject   destroyObj;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(destroyObj, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }


}
