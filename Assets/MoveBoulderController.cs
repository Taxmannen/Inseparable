using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveBoulderController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    public float forceX;
    public float velocityX;

    public bool setToDestroy;
    float maxCountdown = 300f;
    float countdown = 300f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(setToDestroy);
        Debug.Log(countdown);

        if (rb.velocity.x < velocityX)
            rb.AddForce(new Vector3(forceX * Time.deltaTime, 0f, 0f));

        if (setToDestroy)
        {
            countdown--;
            Color c = sr.color;
            c.a = (countdown / maxCountdown);
            Debug.Log(c.a);
            sr.color = c;
        }

        if (countdown == 0)
        {
            Destroy(gameObject);
        }
    }
}
