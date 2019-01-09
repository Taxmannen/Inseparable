using UnityEngine;

//Script made by Jocke
public class SawBlades : MonoBehaviour {
    float rotation;
    public float rotationSpeed;

    private void FixedUpdate()
    {
        Rotation();
    }

    public void Rotation()
    {
        rotation += Time.deltaTime * rotationSpeed;

        if (rotation >= 360)
        {
            rotation %= 360;
        }
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
