using UnityEngine;

/* Script made by Jocke */
public class RespawnableObject : MonoBehaviour {
    [SerializeField] Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("PhysicalObject"))
        {
            other.transform.position = spawnPoint.position;
        }
    }
}
