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
            Debug.LogWarning("�ټ��� ���Ӹ޴����� ����ǰ� �־��.");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
