using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoulderZone : MonoBehaviour
{
    public LayerMask boulderLayer;
    public Vector2 boxSize;

    public bool drawGizmo;

    // Update is called once per frame
    void Update() {
        Collider2D[] collision = Physics2D.OverlapBoxAll(transform.position, boxSize, 0, boulderLayer);
        foreach(Collider2D c2d in collision) {
            c2d.gameObject.GetComponent<MoveBoulderController>().setToDestroy = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmo)
        {
            Gizmos.DrawCube(transform.position, boxSize);
        }
    }
}
