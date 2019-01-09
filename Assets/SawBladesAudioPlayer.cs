using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladesAudioPlayer : MonoBehaviour
{
    public Transform Player1Postion;
    public Transform Player2Postion;

    public float player1DistanceX;
    public float player1DistanceY;
    public float player2DistanceX;
    public float player2DistanceY;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0f;
    }

    private void FixedUpdate()
    {
        CalculateDistance();

        if ((player1DistanceX <= 16 && player1DistanceY <= 16) || (player2DistanceX <= 16 && player2DistanceY <= 16))
        {
            audioSource.volume = 0.1f;
            if ((player1DistanceX <= 14 && player1DistanceY <= 14) || (player2DistanceX <= 14 && player2DistanceY <= 14)) audioSource.volume = 0.2f;
            if ((player1DistanceX <= 12 && player1DistanceY <= 12) || (player2DistanceX <= 12 && player2DistanceY <= 12)) audioSource.volume = 0.3f;
            if ((player1DistanceX <= 10 && player1DistanceY <= 10) || (player2DistanceX <= 10 && player2DistanceY <= 10)) audioSource.volume = 0.4f;
            if ((player1DistanceX <= 9 && player1DistanceY <= 9) || (player2DistanceX <= 9 && player2DistanceY <= 9)) audioSource.volume = 0.5f;
            if ((player1DistanceX <= 8 && player1DistanceY <= 8) || (player2DistanceX <= 8 && player2DistanceY <= 8)) audioSource.volume = 0.6f;
            if ((player1DistanceX <= 5 && player1DistanceY <= 5) || (player2DistanceX <= 5 && player2DistanceY <= 5)) audioSource.volume = 0.8f;
        }
      
        else audioSource.volume = 0f;
    }

    void CalculateDistance()
    {
        player1DistanceX = transform.position.x - Player1Postion.position.x;
        player1DistanceY = transform.position.y - Player1Postion.position.y;
        player2DistanceX = transform.position.x - Player2Postion.position.x;
        player2DistanceY = transform.position.y - Player2Postion.position.y;
    }
}
