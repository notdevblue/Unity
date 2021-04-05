using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float hp = 200.0f;
    public GameObject bloodEffect;


    public void OnDamage(float damage, Vector3 hitPos, Vector3 hitNomal)
    {
        hp -= damage;

        GameObject prefab = Instantiate(bloodEffect, hitPos, Quaternion.LookRotation(hitNomal), this.transform);
        Destroy(prefab, 1.0f);

        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
