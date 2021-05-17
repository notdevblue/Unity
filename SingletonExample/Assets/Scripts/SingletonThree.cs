using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제일 많이 씀
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
                    // 하이라키에서 안 보이고 씬에 저장 안됨. Resocres.UnloadUnusedAssets 에 언로드되지 않음
                    // 스크립트로 만들어지고 TODO : 뒤 매모
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
