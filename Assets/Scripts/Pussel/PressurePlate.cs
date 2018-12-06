using UnityEngine;

/* Made by Daniel */
public class PressurePlate : MonoBehaviour {

    public string[] tags;
    public bool on;

    private void OnTriggerStay2D(Collider2D other)
    {
        //if (other.tag == "Player" || other.tag == "PhysicalObject")
        if (other.tag == tags[0])
        {
            on = true;
            transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.tag == "Player" || other.tag == "PhysicalObject")
        if (other.tag == tags[0])
        {
            on = false;
            transform.localScale = new Vector3(transform.localScale.x, 0.2f, transform.localScale.z);
        }
    }
}
