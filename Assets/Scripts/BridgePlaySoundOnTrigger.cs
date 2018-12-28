using UnityEngine;

/* Script made by Jocke */
public class BridgePlaySoundOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bridge")
        {
            AudioManager.Play("Bridge");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Bridge")
        {
            AudioManager.Stop("Bridge");
        }
    }
}
