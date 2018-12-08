using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script made by Adam */
public class CameraManager : MonoBehaviour {
    public Transform left;
    public Transform right;
    public Transform top;
    public Transform bottom;

    Transform player1;
    Transform player2;

    List<ScrollingBackground> backgrounds;

    public float fractionFromNewPositon;
    public bool limitLess;
    public float lerpidometer;
    
    void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;

        backgrounds = new List<ScrollingBackground>();
        Transform bg = GameObject.Find("Scrolling Background").transform;
        foreach (Transform t in bg) backgrounds.Add(t.GetComponent<ScrollingBackground>());
    }

    void LateUpdate()
    {
        foreach(ScrollingBackground b in backgrounds)
        {
            if (b!= null) b.update();
        }

        float x, y;
        if (!limitLess)
        { 
            x = Mathf.Clamp((player1.position.x + player2.position.x) * 0.5f,
                left.position.x + Camera.main.orthographicSize * Camera.main.aspect,
                right.position.x - Camera.main.orthographicSize * Camera.main.aspect);

            y = Mathf.Clamp((player1.position.y + player2.position.y) * 0.5f,
                bottom.position.y + Camera.main.orthographicSize,
                top.position.y - Camera.main.orthographicSize);
        }
        else
        {
            if (player1 == null || player2 == null)
            {
                player1 = GameObject.Find("Player 1").transform;
                player2 = GameObject.Find("Player 2").transform;
            }
            x = (player1.position.x + player2.position.x) * 0.5f;
            y = (player1.position.y + player2.position.y) * 0.5f;
        }
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10f), new Vector3(x, y, -10f), lerpidometer * Time.deltaTime);
    }
}