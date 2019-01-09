using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Made By Jocke
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
            playerColor.a = f;
            rendererPlayer.color = playerColor;

            for (float fArm = 1f; fArm >= 0; fArm -= 0.01f)
            {
                Color armColor = rendererLeftArm.color;
                armColor.a = fArm;
                rendererRightArm.color = armColor;
                rendererLeftArm.color = armColor;
            }

            yield return new WaitForSeconds(.005f);
        }
    }
    IEnumerator FadeBack()
    {
        Color playerColor = rendererPlayer.color;
        Color armColor = rendererLeftArm.color;
        for (float f = 0.5f; f <= 1; f += 0.01f)
        {
            playerColor.a = f;
            rendererPlayer.color = playerColor;
            yield return new WaitForSeconds(.005f); 
        }
        armColor.a = 1f;
        rendererRightArm.color = armColor;
        rendererLeftArm.color = armColor;
    }
}
