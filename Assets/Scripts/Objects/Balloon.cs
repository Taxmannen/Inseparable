using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float timer;

    SpriteRenderer sr;
    bool pickedUp;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && ! pickedUp)
        {
            pickedUp = true;
            other.GetComponent<BalloonPowerUp>().on = true;
            other.GetComponent<BalloonPowerUp>().timer = timer;
            sr.enabled = false;
            Invoke("Respawn", timer);
        }
    }

    void Respawn()
    {
        sr.enabled = true;
        pickedUp = false;
    }
}
