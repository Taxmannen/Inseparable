using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by Jocke
public class SawBladesAudioPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private void FixedUpdate()
    {
        if(GetPlayer.player1Ready() && GetPlayer.player2Ready())
        {
            float player1Distance = (GetPlayer.getPlayerByName("Player 1").position - transform.position).magnitude;
            float player2Distance = (GetPlayer.getPlayerByName("Player 2").position - transform.position).magnitude;

            float closest = Mathf.Min(player1Distance, player2Distance);

            if (closest < 10)
            {
                audioSource.Play();
                audioSource.volume = Mathf.Clamp(1f - closest / 16f, 0f, 1f);
            }

            else audioSource.Stop();
        }
    }
}
