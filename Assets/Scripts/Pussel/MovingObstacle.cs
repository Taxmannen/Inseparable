using UnityEngine;

public class MovingObstacle : MonoBehaviour {
    public float endPosX;
    public float speed;
    public bool on;
    public bool drawGizmos;

	void Update ()
    {
		if (on)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(endPosX, transform.position.y), speed/100);
        }
	}

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.DrawCube(new Vector2(endPosX, transform.position.y), transform.localScale);
        }
    }
}
