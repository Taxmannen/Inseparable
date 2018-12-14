using UnityEngine;

/* Script made by Daniel */
public class LoadLevel : MonoBehaviour {
    public string sceneName;

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
            levelManager.Load(sceneName);
            loading = true;
        }
    }
}
