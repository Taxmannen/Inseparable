using UnityEngine;

/* Script made by Daniel */
public class ScrollingBackground : MonoBehaviour {
    [Range(0.005f, 0.05f)]
    public float scrollSpeed;
    [Range(0.05f, 0.3f)]
    public float flat;
    public bool moveWithTime;

    Renderer rend;
    Transform cam;
    float offset;
    float oldX;

    void Start()
    {
        rend = GetComponent<Renderer>();
        cam = GameObject.Find("Main Camera").transform;
        oldX = cam.position.x;
    }
    
    public void FixedUpdate()
    {
        float deltaX = (oldX - cam.position.x);
        if (moveWithTime) deltaX -= Time.deltaTime;
        offset += (deltaX) * 1 * flat * scrollSpeed;   
        
        rend.material.mainTextureOffset = new Vector2(offset, 0);
        oldX = cam.transform.position.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0.01f);
    }
}
