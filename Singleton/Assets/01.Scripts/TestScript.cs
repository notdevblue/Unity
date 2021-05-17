using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        Fishbread a = new Fishbread();
        a.redBean = 95.0f;
        a.flour = 100.0f;
        Fishbread.a = a;

        Fishbread b = new Fishbread();
        b.redBean = 5.0f;
        b.flour = 10.0f;
        Fishbread.b = b;
    }
}
