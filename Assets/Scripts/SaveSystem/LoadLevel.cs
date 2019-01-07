using UnityEngine;

/* Script made by Daniel */
public class LoadLevel : MonoBehaviour {
    public string sceneName;
    public Vector2 startPos;
    LevelManager levelManager;
    bool loading;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        levelManager = GameObject.Find("Loading Screen").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !loading)
        {
            loading = true;
            GameSettings gs = GameObject.Find("Main").GetComponent<GameSettings>();
            gs.player1PosX = startPos.x;
            gs.player1PosY = startPos.y;

            levelManager.Load(sceneName);
        }
    }
}
