using UnityEngine;

/* Script made by Daniel */
public class MovingObstacle : MonoBehaviour {
    public int damage;
    public float damageRate;
    public float endPosX;
    public float speed;
    public bool on;
    public bool drawGizmos;

    float timer;

    void Update ()
    {
        timer -= Time.deltaTime;
		if (on) transform.position = Vector3.MoveTowards(transform.position, new Vector2(endPosX, transform.position.y), speed/100);
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (timer <= 0)
            {
                playerStats.TakeHealth(damage);
                timer = damageRate;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos) Gizmos.DrawCube(new Vector2(endPosX, transform.position.y), transform.localScale);
    }
}
