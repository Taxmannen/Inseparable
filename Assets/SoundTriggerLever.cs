using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerLever : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Stick")
        {
            AudioManager.Play("Lever");
        }
    }
}
