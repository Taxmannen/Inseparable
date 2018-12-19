using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeParticleSystemController : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.name == "Bridge") particleSystem.Play();
    }
}
