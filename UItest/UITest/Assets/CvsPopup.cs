using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CvsPopup : MonoBehaviour
{
    [SerializeField] private Button btnClose;

    private void Awake()
    {
        btnClose.onClick.AddListener(delegate
        {
            OnBtnClick();
        });
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        btnClose.gameObject.SetActive(false);
        Invoke(nameof(ShowBtn), 3.0f);
    }


    private void ShowBtn()
    {
        btnClose.gameObject.SetActive(true);
        StartCoroutine(moveButton());
    }

    private void OnBtnClick()
    {
        this.gameObject.SetActive(false);
    }


    private IEnumerator moveButton()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            btnClose.transform.position = new Vector2(Random.Range(0.0f, 1280.0f), Random.Range(0.0f, 720.0f));
        }
    }
}
