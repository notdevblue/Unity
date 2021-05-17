using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ��
public class SingletonThree : MonoBehaviour
{
    private static SingletonThree _instance = null;
    public static SingletonThree instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(SingletonThree)) as SingletonThree;

                if(_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "PropertyObj";
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    // ���̶�Ű���� �� ���̰� ���� ���� �ȵ�. Resocres.UnloadUnusedAssets �� ��ε���� ����
                    // ��ũ��Ʈ�� ��������� TODO : �� �Ÿ�
                    _instance = obj.AddComponent<SingletonThree>();
                }
            }

            return _instance;
        }


    }


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
