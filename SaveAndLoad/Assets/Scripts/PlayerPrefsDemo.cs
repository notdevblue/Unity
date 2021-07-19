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
            print("현제 채력을 저장했다.");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            print($"현제 채력을 불러왔다. : {PlayerPrefs.GetInt("curhp")}");
        }
    }
}
