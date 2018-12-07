using UnityEngine;

/* Made by Daniel */
public class PressurePlate : MonoBehaviour {
    public string[] affectedTags;
    public bool on;

    private void OnTriggerStay2D(Collider2D other)
    {
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag)
            {
                on = true;
                transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag)
            {
                on = false;
                transform.localScale = new Vector3(transform.localScale.x, 0.2f, transform.localScale.z);
            }
        }
    }
}
