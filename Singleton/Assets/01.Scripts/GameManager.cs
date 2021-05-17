using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score {get; private set;}
    public Text scoreTest;  
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreTest.text = $"{score} Á¡";
    }
}
