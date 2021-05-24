using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerTr;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("다수의 게임메니저가 실행되고 있어요.");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
