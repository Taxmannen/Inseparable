using UnityEngine;

/* Script made by Michael */
public class ParticleScript : MonoBehaviour
{
    public GameObject particle;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        { 
            Instantiate(particle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, 0)); //Instantiate Particle at button's position
        }
    }
}
