using UnityEngine;

/* Script made by Daniel */
public class Gate : MonoBehaviour {
    [Range(1f, 5f)]
    public float speed;
    public Vector2 endPos;
    public bool drawGizmos;

    PressurePlate pressurePlate;
    PressurePlate pressurePlate1;


	void Start ()
    {
        pressurePlate  = transform.parent.GetChild(1).GetComponent<PressurePlate>();	
        pressurePlate1 = transform.parent.GetChild(2).GetComponent<PressurePlate>();	
	}
	
	void Update ()
    {
		if (pressurePlate.on && pressurePlate1.on)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x + endPos.x, endPos.y), speed/100);
        }
	}

    private void OnDrawGizmos()
    {
        if (drawGizmos) Gizmos.DrawCube(new Vector2(transform.position.x + endPos.x, endPos.y), transform.localScale);
    }
}
