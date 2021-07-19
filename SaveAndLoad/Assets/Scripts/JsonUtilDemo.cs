using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtilDemo : MonoBehaviour
{

    const string saveFileName = "jsonUtilFile.duck";
    
    [SerializeField]
    private string name = "����� ���� ��";
    
    [SerializeField] // <= ���� ������ �̶�� �ǹ̵� ����
    [HideInInspector]
    private int level = 18; // ���常 �ǰ� ��

    [System.NonSerialized] // ������ �ȵǰ� ��, �ܺ� ������ ��
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
                // �������� �ٲ��ִ� �Լ�

                print(str);
                sr.Close();
            }
            else
            {
                Debug.LogError("�� ������ ������");
            }
            
        }
    }
}
