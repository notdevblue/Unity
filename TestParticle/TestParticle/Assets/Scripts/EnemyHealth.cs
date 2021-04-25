using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHp = 100.0f;
    private float currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }


    private void OnParticleCollision(GameObject other)
    {
        currentHp -= 10;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Invoke(nameof(Respawn), 5.0f);
        this.gameObject.SetActive(false);
    }

    private void Respawn()
    {
        hp = 100.0f;
        this.gameObject.SetActive(true);
    }
}
