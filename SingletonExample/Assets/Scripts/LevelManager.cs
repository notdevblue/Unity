using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonSingleton<LevelManager>
{
    public override void Init()
    {
        base.Init();
    }

    public void LoadLevel()
    {
        Debug.Log("레벨을 로드해준다.");
    }
}
