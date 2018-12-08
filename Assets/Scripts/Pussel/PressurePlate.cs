using UnityEngine;

/* Script made by Daniel */
public class PressurePlate : MonoBehaviour {
    public string[] affectedTags;
    public float startScaleY = 0.1f;
    public float endScaleY= 0.05f;
    public bool on;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, startScaleY, transform.localScale.z);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag)
            {
                on = true;
                transform.localScale = new Vector3(transform.localScale.x, endScaleY, transform.localScale.z);
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
                transform.localScale = new Vector3(transform.localScale.x, startScaleY, transform.localScale.z);
            }
        }
    }
}
