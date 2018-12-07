using UnityEngine;

public class RespawnableObject : MonoBehaviour {
    [SerializeField] Transform spawnPoint;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("PhysicalObject"))
        {
            other.transform.position = spawnPoint.position;
        }
    }
}
