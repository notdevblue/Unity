using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBasic : MonoBehaviour
{
    private static SingletonBasic instance = null;
    public static SingletonBasic GetInstance()
    {
        if(instance == null)
        {
            instance = GameObject.FindObjectOfType(typeof(SingletonBasic)) as SingletonBasic;
            if(!instance)
            {
                Debug.LogError("ã�� �̸��� Ŭ������ �����ϴ�.");
            }
        }

        return instance;
    }
}
