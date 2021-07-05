using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text txtTalk = null;
    public GameObject scanObj = null;
    public GameObject talkPanel = null;
    public bool isAction = false;

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            this.scanObj = scanObj;
            txtTalk.text = $"�̰��� �̸��� {this.scanObj.name} �̶�� �Ѵ�.";
        }

        talkPanel.SetActive(isAction);
    }
    


}
