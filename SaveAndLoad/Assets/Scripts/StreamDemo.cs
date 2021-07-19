using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamDemo : MonoBehaviour
{
    const string saveFileName = "streamFile.duck";
    private string name = "우앱이 였던 것";
    private int level = 18;

    private string GetFilePath(string filename)    // Update is called once per frame
    {
        return Application.persistentDataPath + "/" + filename;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Save to : " + GetFilePath(saveFileName));

            StreamWriter sw = new StreamWriter(GetFilePath(saveFileName));
            sw.WriteLine(name);
            sw.WriteLine(level);

            // 파일은
            // 닫아야
            // 합니다
            // 소켓과
            // 비슷함
            sw.Close();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Load to : " + GetFilePath(saveFileName));

            StreamReader sr = new StreamReader(GetFilePath(saveFileName));
            print(sr.ReadLine());
            print(sr.ReadLine());

            sr.Close();
        }
    }
}
