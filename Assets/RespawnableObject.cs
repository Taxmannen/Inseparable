using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableObject : MonoBehaviour {
    public Vector2 pos;
    public Vector2 size;
    public bool drawGizmos;

    //Vector2 startPos;

    void Start ()
    {
        //startPos = transform.position;
	}


    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawCube(new Vector2(transform.position.x + pos.x, transform.position.y + pos.y), size);
        }
    }
}
