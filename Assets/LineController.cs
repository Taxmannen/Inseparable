using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

    public Transform previous;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update ()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, previous.position);
	}
}
