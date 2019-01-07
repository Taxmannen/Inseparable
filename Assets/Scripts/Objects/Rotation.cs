using UnityEngine;

// Script made by Jocke
public class Rotation : MonoBehaviour {
    public float rotation;
    public float speed;

    void FixedUpdate () {
        rotation += Time.deltaTime * speed;
        
        if (rotation >= 360)
        {
            rotation %= 360;
        }
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
