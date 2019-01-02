using UnityEngine;

public class Blade : MonoBehaviour
{
    float speed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, (speed * Time.deltaTime)));
    }

    public void SetRotationSpeed(float speed)
    {
        this.speed = speed;
    }
}
