using UnityEngine;

/* Script made by Daniel */
public class MovingObstacle : MonoBehaviour {
    public int damage;
    public int damageRate;
    public float endPosX;
    public float speed;
    public bool on;
    public bool drawGizmos;

    void Update ()
    {
		if (on) transform.position = Vector3.MoveTowards(transform.position, new Vector2(endPosX, transform.position.y), speed/100);
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            playerStats.TakeHealth(damage); 
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos) Gizmos.DrawCube(new Vector2(endPosX, transform.position.y), transform.localScale);
    }

}
