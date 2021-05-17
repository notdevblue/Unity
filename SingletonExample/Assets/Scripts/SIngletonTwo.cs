using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIngletonTwo : MonoBehaviour
{
    private static SIngletonTwo instance = null;
    private static GameObject container;
    public static SIngletonTwo GetInstane()
    {
        if(instance == null)
        {
            container = new GameObject();
            container.name = "SingletonContainer";
            instance = container.AddComponent(typeof(SIngletonTwo)) as SIngletonTwo;
        }

        return instance;
    }
}
