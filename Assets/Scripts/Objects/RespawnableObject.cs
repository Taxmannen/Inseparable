using UnityEngine;

// Script made by Jocke
public class RespawnableObject : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public bool touchingGround;
    public bool touchedByPlayer;
    Vector2 speed;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (Vector3.Distance(transform.position, GameObject.Find("Player 1").transform.position) < 30)
            {
                if (Vector3.Distance(transform.position, GameObject.Find("Player 2").transform.position) < 30)
                {
                    AudioManager.Play("ObjectCollision");
                }
            }            
        }
    }
}