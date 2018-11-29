using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Script made by Daniel */
public class LevelManager : MonoBehaviour {
    public float speed = 0.01f;
  
    Image loadingImage;
    Color tmp;
    bool start;
    float alpha;

    private void Start()
    {
        loadingImage = GetComponent<Image>();
    }

    private void Update()
    {
        SetAlpha(start);
    }

    public void Load(string scene)
    {
        StartCoroutine(LoadingScreen(scene));
    }

    private IEnumerator LoadingScreen(string scene)
    {
        start = true;

        while (tmp.a < 1f) yield return null;

        StartCoroutine(LoadLevel(scene));
    }

    private IEnumerator LoadLevel(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone) yield return null;

        start = false;
    }

    private void SetAlpha(bool load)
    {
        if      (alpha < 1 && load)  alpha += speed;
        else if (alpha > 0 && !load) alpha -= speed;
        if      (alpha < 0) alpha = 0;
        else if (alpha > 1) alpha = 1;

        tmp = loadingImage.color;
        tmp.a = alpha;
        loadingImage.color = tmp;
    }
}
    