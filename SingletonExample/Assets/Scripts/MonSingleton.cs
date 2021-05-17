using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonSingleton<T> : MonoBehaviour where T : MonSingleton<T>
{
    private static T _instance;
    public static T instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("_instance is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this as T;

        Init();
    }

    public virtual void Init()
    {
        Debug.Log("Called Base Init");
    }
}
