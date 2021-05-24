using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICvsTopBar : MonoBehaviour
{
    [SerializeField] private Button         btnPopup;
    [SerializeField] private UIPopupBasic   popupObj;

    private void Awake()
    {
        if(btnPopup != null)
        {
            //btnPopup.onClick.AddListener(callPopupFunc);
            btnPopup.onClick.AddListener(delegate
            {
                callPopupFunc();
            });
        }
    }

    void callPopupFunc()
    {
        Debug.Log("callPopupFunc");
        popupObj.Init();
    }
}
