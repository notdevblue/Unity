using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDemo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetInt("curhp", 100);
            print("���� ä���� �����ߴ�.");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            print($"���� ä���� �ҷ��Դ�. : {PlayerPrefs.GetInt("curhp")}");
        }
    }
}
