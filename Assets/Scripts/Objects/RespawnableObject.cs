using UnityEngine;

public class RespawnableObject : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public bool touchingGround;
    public bool touchedByPlayer;
    Vector2 speed;

    //Rigidbody2D rb;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.transform.CompareTag("PhysicalObject"))
        {
            other.transform.position = spawnPoint.position;
        }
        */

        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            AudioManager.Play("ObjectCollision");
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            AudioManager.Play("ObjectCollision");
            Debug.Log("Collided with ground");
        }
    }


    private void Update()
    {
        /*
        speed = rb.GetPointVelocity(transform.TransformPoint(new Vector2(transform.position.x, transform.position.y)));
        Debug.Log(speed.y);
        */
    }

}

internal class RigidBody2D
{
}