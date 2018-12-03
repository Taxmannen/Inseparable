using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPlayer : MonoBehaviour {
    public LayerMask layer;
    public float affectedAreaSize;
    public bool drawGizmos;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        bool canPickup = Physics2D.OverlapCircle(transform.position, affectedAreaSize, layer);
	}

    private void OnDrawGizmos()
    {
        if (drawGizmos) Gizmos.DrawSphere(transform.position, affectedAreaSize);
    }
}
