using UnityEngine;
using UnityEngine.UI;

/* Script made by Daniel */
public class AutoSave : MonoBehaviour {
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
            //CREATE SAVE FILE!
            autoSave = true;
        }
    }
}
