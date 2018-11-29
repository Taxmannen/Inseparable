using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {
    public float speed = 0.01f;
  
    Image loadingImage;
    Color tmp;
    bool start;
    float alpha;

    private void Start()
    {
        loadingImage = GetComponentInChildren<Image>();
    }

    void Update()
    {
        //if (Input.GetButtonDown("Submit")) StartCoroutine(Screen());
        SetAlpha(start);
    }

    void SetAlpha(bool load)
    {
        if      (alpha < 1 && load)  alpha += speed;
        else if (alpha > 0 && !load) alpha -= speed;
        if      (alpha < 0) alpha = 0;
        else if (alpha > 1) alpha = 1;

        tmp = loadingImage.color;
        tmp.a = alpha;
        loadingImage.color = tmp;
    }


    private IEnumerator Screen(/*string level, bool reload*/)
    {
        start = true;

        while (tmp.a < 1f) yield return null;

        StartCoroutine(Load());
    }

    private IEnumerator Load(/*string level, bool reload*/)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main"/*level*/);

        while (!asyncLoad.isDone) yield return null;

        start = false;
    }
}
