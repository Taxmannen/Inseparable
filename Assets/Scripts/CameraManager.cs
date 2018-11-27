using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    Transform player1;
    Transform player2;

    public float fractionFromNewPositon;

    void Start()
    {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;
    }

    // Update is called once per frame
    void Update() {
        Vector3 medianPosition = (player1.position + player2.position) * 0.5f;

        Vector3 newPosition = this.gameObject.transform.position * (1 - fractionFromNewPositon) + medianPosition * fractionFromNewPositon;
        newPosition.z = -10;
        this.gameObject.transform.position = newPosition;
	}
}