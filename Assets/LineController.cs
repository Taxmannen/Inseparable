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
    }

    public void Setup(Transform previous, Material material, float width)
    {
        Debug.Log(line);
        this.previous = previous;
        line.startWidth = width;
        line.endWidth = width;
        line.material = material;
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
