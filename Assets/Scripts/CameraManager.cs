using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    Transform player1;
    Transform player2;

    public float fractionFromNewPositon;
    public float minCameraX, maxCameraX;

    void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
    }

    // Update is called once per frame
    void _Update()
    {
        float medianXPosition = (player1.position.x + player2.position.x) * 0.5f;

        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x * (1 - fractionFromNewPositon) + medianXPosition * fractionFromNewPositon,
            this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }

    void FixedUpdate()
    {
        float x = (player1.position.x + player2.position.x) * 0.5f;
        if ((player1.position.x + player2.position.x * 0.5f) < minCameraX)
            x = minCameraX;

        if ((player1.position.x + player2.position.x * 0.5f) > maxCameraX)
            x = maxCameraX;

        Vector3 medianPosition = new Vector3(x, ((player1.position + player2.position) * 0.5f).y, ((player1.position + player2.position) * 0.5f).z);

        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10f), new Vector3(medianPosition.x, transform.position.y, -10f), 3f * Time.deltaTime);
    }
}