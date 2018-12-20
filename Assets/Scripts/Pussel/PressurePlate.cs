using UnityEngine;

/* Script made by Daniel */
public class PressurePlate : MonoBehaviour {
    public string[] affectedTags;
    public bool on;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(anim);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag && !other.isTrigger)
            {
                on = true;
                anim.Play("Pressure Plate On");
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag && !other.isTrigger)
            {
                AudioManager.Play("PressurePlateOff");
                anim.Play("Pressure Plate Off");
                on = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in affectedTags)
        {
            if (other.tag == tag && !other.isTrigger && !on)
            {
                AudioManager.Play("PressurePlateOn");
            }
        }
    }
}
