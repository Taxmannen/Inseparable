using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float timer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<BalloonPowerUp>().on = true;
            other.GetComponent<BalloonPowerUp>().timer = timer;
            Destroy(gameObject);
        }
    }
}
