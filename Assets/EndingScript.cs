using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public Rigidbody2D player1;
    public Rigidbody2D player2;
    bool toWalk;

    void Start()
    {
        Invoke("Walk", 0.2f);
    }

    void Update()
    {
        if (toWalk)
        {
            if (player1.velocity.x < 3 && player1.transform.localPosition.x < 14)
            {
                Debug.Log("Walk");
                player1.AddForce(new Vector2(10, 0));
                player2.AddForce(new Vector2(10, 0));
            }
            if (player1.transform.localPosition.x >= 14)
            {
                Debug.Log("Stop");
                player1.velocity = Vector2.zero;
                player2.velocity = Vector2.zero;
                player1.GetComponent<BalloonPowerUp>().on = true;
            }
        }
    }

    void Walk()
    {
        toWalk = true;  
    }
}
