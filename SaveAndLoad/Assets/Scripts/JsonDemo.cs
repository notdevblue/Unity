using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class JsonDemo : MonoBehaviour
{
    const string saveFileName = "jsonFile.duck";
    private string name = "����� ���� ��";
    private int level = 18;
    public string[] friends;

    private string GetFilePath(string filename)    // Update is called once per frame
    {
        return Application.persistentDataPath + "/" + filename;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Save to : " + GetFilePath(saveFileName));

            JObject jObj = new JObject();
            jObj.Add("componentName", GetType().ToString());

            JObject jDataObj = new JObject();
            jObj.Add("data", jDataObj);

            jDataObj.Add("name", name);
            jDataObj.Add("level", level);

            JArray jFriendsArray = JArray.FromObject(friends);
            jDataObj.Add("friends", jFriendsArray);

            // ����
            StreamWriter sw = new StreamWriter(GetFilePath(saveFileName));
            sw.WriteLine(jObj.ToString());
            sw.Close();

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Load to : " + GetFilePath(saveFileName));

            StreamReader sr = new StreamReader(GetFilePath(saveFileName));
            string jsonString = sr.ReadToEnd();
            sr.Close();

            print(jsonString);

            // �о�帰 �����͸� JObject �� ���ؼ� �簡��
            JObject jObj = JObject.Parse(jsonString);
            name = jObj["data"]["name"].Value<string>();
            level = jObj["data"]["level"].Value<int>();
            friends = jObj["data"]["friends"].ToObject<string[]>();

            print(name);
            print(level);
            foreach (var item in friends)
            {
                print(item);
            }

        }
    }
}