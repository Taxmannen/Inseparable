using UnityEngine;
using UnityEngine.UI;

/* Script made by Daniel */
public class AutoSave : MonoBehaviour {
    GameSettings gs;
    Image icon;
    bool autoSave;
    float alpha = 1;
    float speed = 1;
    float timer;
    int counter;

	void Start ()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        icon = GameObject.Find("Auto Save Icon").GetComponent<Image>();
        gs = GameObject.Find("Main").GetComponent<GameSettings>();
    }

    private void Update()
    {
        if (autoSave)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                icon.CrossFadeAlpha(alpha, speed, false);
                if (alpha == 1) alpha = 0;
                else            alpha = 1;
                timer = speed;
                counter++;
            }
            if (counter == 8) Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!autoSave && other.tag == "Player")
        {
            gs.Save();
            autoSave = true;
        }
    }
}
