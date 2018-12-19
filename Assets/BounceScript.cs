using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public PhysicsMaterial2D material;
    public float bounciness = 3f;

    void Start()
    {
        material.bounciness = bounciness;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player 1" || other.gameObject.name == "Player 2")
        {
            Debug.Log("hit");
            Debug.Log(other.GetComponent<Rigidbody2D>());                        
        }
    }
}
