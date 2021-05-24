using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIPopupBasic : MonoBehaviour
{
    public Transform    panelTransform;
    public Transform    tapToCloseTrm;
    public Button       btnBlank;

    private Sequence    seq1, seq2;

    private void Awake()
    {
        if(btnBlank != null)
        {
            btnBlank.onClick.AddListener(delegate
            {
                callCloseFunc();
            });
        }
    }

    public void Init()
    {
        if(btnBlank != null)
        {
            btnBlank.interactable = false;
        }

        if(tapToCloseTrm != null)
        {
            tapToCloseTrm.gameObject.SetActive(false);
        }

        seq1.Kill();
        seq2.Kill();

        panelTransform.localScale = Vector3.zero;
        panelTransform.gameObject.SetActive(true);

        seq1 = DOTween.Sequence();
        seq1.Append(panelTransform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f)); // 시퀀스에 추가함
        seq1.Append(panelTransform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.2f));

        seq1.AppendCallback(() =>
        {
            if (tapToCloseTrm != null)
            {
                tapToCloseTrm.localScale = Vector3.zero;
                tapToCloseTrm.gameObject.SetActive(true);

                seq2 = DOTween.Sequence();
                seq2.Append(tapToCloseTrm.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 1.5f));
                seq2.AppendCallback(() =>
                {
                    btnBlank.interactable = true;
                });
            }
        });
    }


    private void callCloseFunc()
    {
        panelTransform.gameObject.SetActive(false);
    }
}
