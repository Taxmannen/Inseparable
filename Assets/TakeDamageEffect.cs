using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEffect : MonoBehaviour
{
    SpriteRenderer rendererPlayer;
    public SpriteRenderer rendererRightArm;
    public SpriteRenderer rendererLeftArm;
    

    private void Start()
    {
        rendererPlayer = GetComponent<SpriteRenderer>();
        rendererPlayer.color = GetComponent<SpriteRenderer>().color;
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
            Color playerColor = rendererPlayer.color;
            Color armColor = rendererLeftArm.color;
            playerColor.a = f;
            armColor.a = f;
            rendererPlayer.color = playerColor;
            rendererRightArm.color = armColor;
            rendererLeftArm.color = armColor;
            yield return new WaitForSeconds(.005f);
        }
    }
    IEnumerator FadeBack()
    {
        for (float f = 0.5f; f <= 1; f += 0.01f)
        {
            Color playerColor = rendererPlayer.color;
            Color armColor = rendererLeftArm.color;
            playerColor.a = f;
            armColor.a = f;
            rendererPlayer.color = playerColor;
            rendererRightArm.color = armColor;
            rendererLeftArm.color = armColor;
            yield return new WaitForSeconds(.005f);
        }
    }
}
