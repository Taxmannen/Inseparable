using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEffect : MonoBehaviour
{
    SpriteRenderer sr;
    Color c;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = GetComponent<SpriteRenderer>().color;
    }

    public void StartFade()
    {
        StartCoroutine("Fade");
        StartCoroutine("FadeBack");
    }

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0.5; f -= 0.01f)
        {
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            yield return new WaitForSeconds(.005f);
        }
    }
    IEnumerator FadeBack()
    {
        for (float f = 0.5f; f <= 1; f += 0.01f)
        {
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            yield return new WaitForSeconds(.005f);
        }
    }
}
