using UnityEngine;

// Script made by Jocke
public class Rotation : MonoBehaviour {
    public float rotation;

    void FixedUpdate () {
        rotation += Time.deltaTime * 10;
        
        if (rotation >= 360)
        {
            rotation %= 360;
        }
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
