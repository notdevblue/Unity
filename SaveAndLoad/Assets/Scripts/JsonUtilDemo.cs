using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtilDemo : MonoBehaviour
{

    const string saveFileName = "jsonUtilFile.duck";
    
    [SerializeField]
    private string name = "우앱이 였던 것";
    
    [SerializeField] // <= 저장 가능함 이라는 의미도 있음
    [HideInInspector]
    private int level = 18; // 저장만 되게 됨

    [System.NonSerialized] // 저장이 안되게 됨, 외부 공개는 됨
    public int age = 100;

    public Transform trm;
    
    private string GetFilePath(string filename)    // Update is called once per frame
    {
        return Application.persistentDataPath + "/" + filename;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Save to : " + GetFilePath(saveFileName));

            string jsonString = JsonUtility.ToJson(this);
            StreamWriter sw = new StreamWriter(GetFilePath(saveFileName));
            sw.WriteLine(jsonString);
            sw.Close();

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Load to : " + GetFilePath(saveFileName));

            string fileStr = GetFilePath(saveFileName);
            if (File.Exists(fileStr))
            {
                StreamReader sr = new StreamReader(fileStr);
                string str = sr.ReadToEnd();
                JsonUtility.FromJsonOverwrite(str, this);
                // 변수들을 바꿔주는 함수

                print(str);
                sr.Close();
            }
            else
            {
                Debug.LogError("오 파일이 없군요");
            }
            
        }
    }
}
