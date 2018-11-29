using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public bool on;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            on = true;
            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            on = false;
            transform.localScale = new Vector3(transform.localScale.x, 0.2f, transform.localScale.z);
        }
    }
}
