using UnityEngine;

/* Script made by Daniel */
public class Gate : MonoBehaviour
{
    [Range(1f, 5f)]
    public float speed;
    public Vector2 endPos;
    public bool drawGizmos;

    PressurePlate pressurePlate;
    PressurePlate pressurePlate1;


    void Start()
    {
        pressurePlate = transform.parent.GetChild(1).GetComponent<PressurePlate>();
        pressurePlate1 = transform.parent.GetChild(2).GetComponent<PressurePlate>();
    }

    void Update()
    {
        if (pressurePlate.on && pressurePlate1.on)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x + endPos.x, endPos.y), speed / 100);
            if (transform.position.y < endPos.y)
                AudioManager.Play("GateOpen");
            else
                AudioManager.Stop("GateOpen");
        }


    }

    private void OnDrawGizmos()
    {
        {
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            if (drawGizmos) Gizmos.DrawCube(new Vector2(transform.position.x + endPos.x, endPos.y), new Vector2(col.size.x, (col.size.y + transform.localScale.y)));
        }
    }
}