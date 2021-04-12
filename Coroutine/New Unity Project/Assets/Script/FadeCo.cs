using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

// 과제 : 변수 하나 만들어서 n, y 초 동안 FadeIn, FadeOut

public enum eFadeState
{
    None,
    FadeOut,
    ChangeBg,
    FadeIn,
    Done
}

public class FadeCo : MonoBehaviour
{
    public eFadeState fadeState = eFadeState.None;
    private Image imgBg;
    private IEnumerator iStateCo = null;
    public float fadeInDelay = 1.0f;
    public float fadeOutDelay = 1.0f;

    private void Awake()
    {
        imgBg = this.gameObject.GetComponent<Image>();
        if (imgBg == null)
        {
            Debug.Log("img is null");
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fadeState == eFadeState.None)
        {
            fadeState = eFadeState.None;
            NextState();
        }
    }

    IEnumerator None()
    {
        while (fadeState == eFadeState.None)
        {
            fadeState = eFadeState.FadeOut;
            yield return null;
        }

        NextState();
    }

    IEnumerator FadeOut()
    {
        float alpha = 0.0f;
        while (fadeState == eFadeState.FadeOut)
        {
            
            if (alpha < 1)
            {
                alpha += Time.deltaTime;
            }
            else
            {
                fadeState = eFadeState.ChangeBg;
            }

            alpha = Mathf.Clamp(alpha, 0, 1);
            imgBg.color = new Color(imgBg.color.r, imgBg.color.g, imgBg.color.b, alpha);

            yield return null;
        }

        NextState();
    }

    IEnumerator FadeIn()
    {
        float alpha = 1.0f;
        while (fadeState == eFadeState.FadeIn)
        {
            
            if (alpha > 0)
            {
                alpha -= Time.deltaTime;
            }
            else
            {
                fadeState = eFadeState.Done;
            }

            alpha = Mathf.Clamp(alpha, 0, 1);
            imgBg.color = new Color(imgBg.color.r, imgBg.color.g, imgBg.color.b, alpha);

            yield return null;
        }

        NextState();
    }

    IEnumerator Done()
    {
        yield return null;

        fadeState = eFadeState.None;
    }

    IEnumerator ChangeBg()
    {
        yield return null;

        Debug.Log("리소스 로딩, ui처리");

        fadeState = eFadeState.FadeIn;

        NextState();
    }


    private void NextState()
    {
        MethodInfo mInfo = this.GetType().GetMethod(fadeState.ToString(), BindingFlags.Instance | BindingFlags.NonPublic);
        iStateCo = (IEnumerator)mInfo.Invoke(this, null);
        Debug.Log(iStateCo);
        StartCoroutine(iStateCo);
    }


}
