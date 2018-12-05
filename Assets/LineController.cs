using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Made by Adam */
[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour {

    public Transform previous;
    public LineRenderer line;
    public Color ropeColor;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Standard"));
    }

    void Setup(Transform previous, Color ropeColor, float width)
    {
        this.previous = previous;
        line.startWidth = line.endWidth = width;
        line.startColor = line.startColor = ropeColor;
    }
    
    void Update ()
    {
        if (previous != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, previous.position);
        }
	}
}
