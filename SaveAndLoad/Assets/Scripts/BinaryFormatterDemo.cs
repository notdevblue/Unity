using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class BinaryFormatterDemo : MonoBehaviour
{
    const string saveFileName = "streamBinaryFormatter.duck";
    private string name = "우앱이 였던 것";
    private int level = 18;

    [System.Serializable] // 클래스가 자동으로 직렬화되게 해줌
    private class DataContainer
    {
        public string _name;
        public int _level;

        public DataContainer(string name, int level)
        {
            _name = name;
            _level = level;
        }
    }

    private string GetFilePath(string filename)    // Update is called once per frame
    {
        return Application.persistentDataPath + "/" + filename;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Save to : " + GetFilePath(saveFileName));

            DataContainer dc = new DataContainer(name, level);

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = new FileStream(GetFilePath(saveFileName), FileMode.OpenOrCreate);

            bf.Serialize(fs, dc);

            fs.Close();

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Load to : " + GetFilePath(saveFileName));

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(GetFilePath(saveFileName), FileMode.Open);

            DataContainer dc = bf.Deserialize(fs) as DataContainer;

            print("name" + dc._name);
            print("level" + dc._level);

            fs.Close();
        }
    }
}
