using UnityEngine;

/* Script made by Daniel */
public class LoadLevel : MonoBehaviour {
    public string sceneName;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("UI").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") levelManager.Load(sceneName);
    }
}
