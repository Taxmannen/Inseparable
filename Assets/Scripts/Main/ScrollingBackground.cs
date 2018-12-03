using UnityEngine;

/* Script made by Daniel */
public class ScrollingBackground : MonoBehaviour {
    [Range(0.01f, 0.1f)]
    public float scrollSpeed;
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
        if (moveWithTime)
            deltaX -= Time.deltaTime;
                
        offset += (deltaX) * scrollSpeed;
        
        rend.material.mainTextureOffset = new Vector2(offset, 0);
        oldX = cam.transform.position.x;

        transform.position = new Vector3(cam.position.x, transform.position.y, 0.01f);
    }
}
