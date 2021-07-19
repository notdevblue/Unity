using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryDemo : MonoBehaviour
{
    const string saveFileName = "streamBinaryFile.duck";
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

            FileStream fs = new FileStream(GetFilePath(saveFileName), FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);


            bw.Write(name);
            bw.Write(level);

            bw.Close();
            fs.Close();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Load to : " + GetFilePath(saveFileName));

            FileStream fs = new FileStream(GetFilePath(saveFileName), FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            print(br.ReadString());
            print(br.ReadInt32());

            br.Close();
            fs.Close();
        }
    }
}
