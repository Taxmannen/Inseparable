using UnityEngine;

/* Made by Adam */
[RequireComponent(typeof(LineRenderer))]
public class LineController : MonoBehaviour {
    public Transform previous;
    public LineRenderer line;
    public Color ropeColor;

    public void Setup(Transform previous, Material material, float width)
    {
        line = GetComponent<LineRenderer>();
        this.previous = previous;
        line.startWidth = width;
        line.endWidth = width;
        line.material = material;
    }
    
    void Update ()
    {
        if (previous != null && line != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, previous.position);
        }
	}
}
