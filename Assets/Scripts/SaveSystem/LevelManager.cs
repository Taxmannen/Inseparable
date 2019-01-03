using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Script made by Daniel */
public class LevelManager : MonoBehaviour {
    public float speed = 0.01f;
    public GameSettings gs;

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
        Main.loading = true;
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
        Startup();
        Invoke("SetStartFalse", 0.5f);
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
    void SetStartFalse()
    {
        start = false;
    }

    private void Startup()
    {
        SaveSystem.Load();
        GameObject.Find("Player 1").transform.position = new Vector2(gs.player1PosX, gs.player1PosY);
        GameObject.Find("Player 2").transform.position = new Vector2(gs.player1PosX + 2, gs.player1PosY);
        GameObject rope = GameObject.Find("Rope");
        rope.transform.position = new Vector2(gs.player1PosX + 1, gs.player1PosY);
        Camera.main.transform.position = new Vector3(gs.player1PosX, gs.player1PosY , -10);

        LeverController.setLeverStates(gs.levers);
        Main.loading = false;
    }
}
    