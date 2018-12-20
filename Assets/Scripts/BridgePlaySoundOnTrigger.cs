using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePlaySoundOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bridge")
        {
            AudioManager.Play("Bridge");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Bridge")
        {
            AudioManager.Stop("Bridge");
        }
    }
}
