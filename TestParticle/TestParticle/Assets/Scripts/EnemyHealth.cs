using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHp = 100.0f;
    private float currentHp;

    private Material material = null;

    private void Awake()
    {
        currentHp = maxHp;
        material = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        Setcolor();
    }

    private void OnParticleCollision(GameObject other)
    {
        Damage();
        
    }

    private void Damage()
    {
        currentHp -= 10;

        if (currentHp <= 0)
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
        currentHp = maxHp;
        this.gameObject.SetActive(true);
    }

    private void Setcolor()
    {
        Color randColor;
        //randColor = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));

        randColor = Random.ColorHSV();
        material.SetColor("_Color", randColor);
    }
}
